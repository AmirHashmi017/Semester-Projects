from PyQt5 import QtCore, QtGui, QtWidgets 
from selenium import webdriver
from selenium.webdriver.common.by import By
from selenium.webdriver.support.ui import WebDriverWait
from selenium.webdriver.support import expected_conditions as EC
from bs4 import BeautifulSoup
from PyQt5.QtGui import QStandardItemModel, QStandardItem
import sys
import pandas as pd
import threading
import time
import os  

BASE_URL = "https://www.zameen.com/Homes/Lahore-1-{}.html"

def init_driver():
    driver = webdriver.Chrome()
    return driver

class ScrapUI(QtWidgets.QWidget):
    update_data_signal = QtCore.pyqtSignal(list)
    update_progress_signal = QtCore.pyqtSignal(int)

    def __init__(self, parent=None):
        super(ScrapUI, self).__init__(parent)
        self.stop_scraping = False 
        self.is_paused = False
        self.driver = None 
        self.setupUi()

    def setupUi(self):
        self.setObjectName("ScrapUI")
        self.resize(800, 600)
        self.verticalLayout_2 = QtWidgets.QVBoxLayout(self)
        self.verticalLayout_2.setObjectName("verticalLayout_2")

        self.widget = QtWidgets.QWidget(self)
        self.widget.setObjectName("widget")
        self.verticalLayout = QtWidgets.QVBoxLayout(self.widget)
        self.verticalLayout.setObjectName("verticalLayout")

        self.frame_2 = QtWidgets.QFrame(self.widget)
        sizePolicy = QtWidgets.QSizePolicy(QtWidgets.QSizePolicy.Preferred, QtWidgets.QSizePolicy.Expanding)
        sizePolicy.setHorizontalStretch(0)
        sizePolicy.setVerticalStretch(0)
        sizePolicy.setHeightForWidth(self.frame_2.sizePolicy().hasHeightForWidth())
        self.frame_2.setSizePolicy(sizePolicy)
        self.frame_2.setFrameShape(QtWidgets.QFrame.StyledPanel)
        self.frame_2.setFrameShadow(QtWidgets.QFrame.Raised)
        self.frame_2.setObjectName("frame_2")

        self.verticalLayout_5 = QtWidgets.QVBoxLayout(self.frame_2)
        self.verticalLayout_5.setObjectName("verticalLayout_5")
        self.tableView = QtWidgets.QTableView(self.frame_2)
        self.tableView.setObjectName("tableView")
        self.verticalLayout_5.addWidget(self.tableView)
        self.verticalLayout.addWidget(self.frame_2)

        self.frame_3 = QtWidgets.QFrame(self.widget)
        self.frame_3.setFrameShape(QtWidgets.QFrame.StyledPanel)
        self.frame_3.setFrameShadow(QtWidgets.QFrame.Raised)
        self.frame_3.setObjectName("frame_3")
        self.verticalLayout_3 = QtWidgets.QVBoxLayout(self.frame_3)
        self.verticalLayout_3.setObjectName("verticalLayout_3")

        self.frame_4 = QtWidgets.QFrame(self.frame_3)
        self.frame_4.setFrameShape(QtWidgets.QFrame.StyledPanel)
        self.frame_4.setFrameShadow(QtWidgets.QFrame.Raised)
        self.frame_4.setObjectName("frame_4")
        self.horizontalLayout = QtWidgets.QHBoxLayout(self.frame_4)
        self.horizontalLayout.setObjectName("horizontalLayout")

        self.pushButton = QtWidgets.QPushButton(self.frame_4)
        self.pushButton.setObjectName("pushButton")
        self.pushButton.setText("Start")
        self.pushButton.clicked.connect(self.start_scraping)
        self.horizontalLayout.addWidget(self.pushButton)

        self.pushButton_2 = QtWidgets.QPushButton(self.frame_4)
        self.pushButton_2.setObjectName("pushButton_2")
        self.pushButton_2.setText("Pause")
        self.pushButton_2.clicked.connect(self.toggle_pause_resume)
        self.horizontalLayout.addWidget(self.pushButton_2)

        self.pushButton_3 = QtWidgets.QPushButton(self.frame_4)
        self.pushButton_3.setObjectName("pushButton_3")
        self.pushButton_3.setText("Stop")
        self.pushButton_3.clicked.connect(self.stop_scraping_process)
        self.horizontalLayout.addWidget(self.pushButton_3)

        self.verticalLayout_3.addWidget(self.frame_4)
        self.progressBar = QtWidgets.QProgressBar(self.frame_3)
        self.progressBar.setProperty("value", 0)
        self.progressBar.setObjectName("progressBar")
        self.verticalLayout_3.addWidget(self.progressBar)
        self.verticalLayout.addWidget(self.frame_3)
        self.verticalLayout_2.addWidget(self.widget)

        self.update_data_signal.connect(self.display_results)
        self.update_progress_signal.connect(self.update_progress)

    def start_scraping(self):
        csv_file_path = 'Data/scraped_homes.csv' 
        if os.path.exists(csv_file_path):
            os.remove(csv_file_path)
        print(f"Deleted existing CSV file: {csv_file_path}")
        self.stop_scraping = False
        threading.Thread(target=self.run_scraping_thread).start()

    def run_scraping_thread(self):
        scraping_thread = threading.Thread(target=self.scrape_homes)
        scraping_thread.start()

    def toggle_pause_resume(self):
        if not self.is_paused:
            self.is_paused = True
            self.pushButton_2.setText("Resume")
        else:
            self.is_paused = False
            self.pushButton_2.setText("Pause")

    def scrape_homes(self):
        all_homes = []
        scraped_pages = 0
        max_scraped_before_restart = 10
        driver = init_driver()
    
        csv_file_path = 'Data/scraped_homes.csv'
        if not os.path.exists(csv_file_path):
            pd.DataFrame(columns=['Title', 'Price', 'Location', 'City', 'Beds', 'Baths', 'Area']).to_csv(csv_file_path, index=False)
    
        try:
            total_pages = 1000
            for page in range(1, total_pages + 1):
                while self.is_paused: 
                    time.sleep(1)
                if self.stop_scraping: 
                    print("Scraping stopped by user.")
                    break
                
                driver.get(BASE_URL.format(page))
                time.sleep(1)
    
                WebDriverWait(driver, 20).until(
                    EC.presence_of_all_elements_located((By.CLASS_NAME, '_5b98ebdf'))
                )
    
                soup = BeautifulSoup(driver.page_source, 'html.parser')
                homes = soup.find_all('article', class_='_5b98ebdf')
                if not homes:
                    print(f"No homes found on page {page}. Check the selectors.")
                    continue
                
                page_homes = []
                for home in homes:
                    try:
                        title = home.find('h2', class_='_36dfb99f').text.strip() if home.find('h2', class_='_36dfb99f') else 'N/A'
                        price = home.find('span', class_='dc381b54').text.strip() if home.find('span', class_='dc381b54') else 'N/A'
                        full_location = soup.find('div', class_='db1aca2f').text.strip() if soup.find('div', class_='db1aca2f') else 'N/A'
    
                        if ',' in full_location:
                            location, city = map(str.strip, full_location.split(',', 1))
                        else:
                            location = full_location
                            city = 'N/A'
    
                        beds = home.find('span', {'aria-label': 'Beds'}).text.strip() if home.find('span', {'aria-label': 'Beds'}) else 'N/A'
                        baths = home.find('span', {'aria-label': 'Baths'}).text.strip() if home.find('span', {'aria-label': 'Baths'}) else 'N/A'
                        area = home.find('span', {'aria-label': 'Area'}).text.strip() if home.find('span', {'aria-label': 'Area'}) else 'N/A'
    
                        # Check if beds and baths are valid (not 'N/A')
                        if beds != 'N/A' and baths != 'N/A':
                            page_homes.append({
                                'Title': title,
                                'Price': price,
                                'Location': location,
                                'City': city,
                                'Beds': beds,
                                'Baths': baths,
                                'Area': area
                            })
    
                    except AttributeError as e:
                        print(f"Error extracting data from home: {e}")
    
                if page_homes:
                    pd.DataFrame(page_homes).to_csv(csv_file_path, mode='a', header=False, index=False)
                progress_value = int((page / total_pages) * 100)
                self.update_progress_signal.emit(progress_value)
                print(f"Scraped page {page}")
                scraped_pages += 1
    
                if scraped_pages >= max_scraped_before_restart:
                    print("Restarting browser after scraping 10 pages.")
                    driver.quit()
                    driver = init_driver()
                    scraped_pages = 0
                read_thread = threading.Thread(target=self.read_homes_data)
                read_thread.start()
            print("Scraping complete!")
    
        except Exception as e:
            print(f"Error occurred during scraping: {e}")
    
        finally:
            driver.quit()

    def stop_scraping_process(self):
        self.stop_scraping = True 
        if self.driver:
            self.driver.quit() 

    def read_homes_data(self):
        csv_file_path = 'Data/scraped_homes.csv'
        if os.path.exists(csv_file_path):
            data = pd.read_csv(csv_file_path).values.tolist()
            self.update_data_signal.emit(data)

    def display_results(self, data):
        model = QStandardItemModel(self.tableView)
        model.setHorizontalHeaderLabels(['Title', 'Price', 'Location', 'City', 'Beds', 'Baths', 'Area'])
        for row_data in data:
            row = [QStandardItem(str(item)) for item in row_data]
            model.appendRow(row)
        self.tableView.setModel(model)

    def update_progress(self, value):
        self.progressBar.setValue(value)

if __name__ == "__main__":
    app = QtWidgets.QApplication(sys.argv)
    window = ScrapUI()
    window.setWindowTitle("Home Scraper")
    window.show()
    sys.exit(app.exec_())
