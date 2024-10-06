# -*- coding: utf-8 -*-

from PyQt5 import QtCore, QtGui, QtWidgets
from PyQt5.QtWidgets import QMessageBox
from selenium import webdriver
from bs4 import BeautifulSoup
import time


class ScraperThread(QtCore.QThread):
    update_browser = QtCore.pyqtSignal(str)  
    error_occurred = QtCore.pyqtSignal(str)   

    def __init__(self, url):
        super().__init__()
        self.url = url

    def run(self):
        driver = webdriver.Chrome()

        try:
            driver.get(self.url)
            time.sleep(5) 
            page_source = driver.page_source

            soup = BeautifulSoup(page_source, 'html.parser')

            # This will store the categorized data
            content_dict = {
                "Headers": [],
                "Links": [],
                "Paragraphs": [],
                "Lists": []
            }

            # Collect data based on the type
            for child in soup.find_all(['h1', 'h2', 'h3', 'p', 'li', 'a']):
                content = child.get_text(strip=True)
                if content:
                    if child.name.startswith('h'):  # Headers
                        content_dict["Headers"].append(content)
                    elif child.name == 'a':  # Links
                        content_dict["Links"].append(content)
                    elif child.name == 'p':  # Paragraphs
                        content_dict["Paragraphs"].append(content)
                    elif child.name == 'li':  # List items
                        content_dict["Lists"].append(content)

            # Create a formatted output string
            content_string = ""
            for header, contents in content_dict.items():
                if contents:  # Only display if there's content
                    content_string += f"<strong>{header}:</strong><br>" + "<br>".join(contents) + "<br><br>"

            if not content_string:
                self.error_occurred.emit("No suitable content found on the page.")
                return

            self.update_browser.emit(content_string)

        except Exception as e:
            self.error_occurred.emit(str(e))
        finally:
            driver.quit()


class Ui_Widget(QtWidgets.QWidget):
    def __init__(self):
        super().__init__()
        self.setupUi()

    def setupUi(self):
        self.setObjectName("MainWindow")
        self.resize(800, 600)

        self.verticalLayout = QtWidgets.QVBoxLayout(self)

        self.frame_2 = QtWidgets.QFrame(self)
        self.frame_2.setFrameShape(QtWidgets.QFrame.StyledPanel)
        self.frame_2.setFrameShadow(QtWidgets.QFrame.Raised)
        self.verticalLayout_5 = QtWidgets.QVBoxLayout(self.frame_2)
        self.textBrowser = QtWidgets.QTextBrowser(self.frame_2)
        self.verticalLayout_5.addWidget(self.textBrowser)
        self.verticalLayout.addWidget(self.frame_2)

        self.frame_3 = QtWidgets.QFrame(self)
        self.frame_3.setFrameShape(QtWidgets.QFrame.StyledPanel)
        self.frame_3.setFrameShadow(QtWidgets.QFrame.Raised)
        self.verticalLayout_3 = QtWidgets.QVBoxLayout(self.frame_3)

        self.frame_4 = QtWidgets.QFrame(self.frame_3)
        self.frame_4.setFrameShape(QtWidgets.QFrame.StyledPanel)
        self.frame_4.setFrameShadow(QtWidgets.QFrame.Raised)
        self.verticalLayout_4 = QtWidgets.QVBoxLayout(self.frame_4)

        self.plainTextEdit = QtWidgets.QPlainTextEdit(self.frame_4)
        self.plainTextEdit.setMaximumSize(QtCore.QSize(16777215, 30))
        self.verticalLayout_4.addWidget(self.plainTextEdit, 0, QtCore.Qt.AlignBottom)

        self.pushButton = QtWidgets.QPushButton(self.frame_4)
        self.pushButton.setObjectName("pushButton")
        self.pushButton.setText("Start")
        self.pushButton.clicked.connect(self.start_scraping)
        self.verticalLayout_4.addWidget(self.pushButton)

        self.verticalLayout_3.addWidget(self.frame_4, 0, QtCore.Qt.AlignBottom)
        self.verticalLayout.addWidget(self.frame_3, 0, QtCore.Qt.AlignBottom)

        self.setLayout(self.verticalLayout)

        self.retranslateUi()

    def retranslateUi(self):
        _translate = QtCore.QCoreApplication.translate
        self.setWindowTitle(_translate("MainWindow", "Web Scraper"))

    def start_scraping(self):
        url = self.plainTextEdit.toPlainText().strip()
        if not url:
            QMessageBox.warning(self, "Input Error", "Please enter a URL.")
            return
        
        self.thread = ScraperThread(url)
        self.thread.update_browser.connect(self.update_text_browser)
        self.thread.error_occurred.connect(self.show_error)
        self.thread.start()

    def update_text_browser(self, content):
        self.textBrowser.clear()
        self.textBrowser.append(content)

    def show_error(self, error_message):
        QMessageBox.warning(self, "Error", error_message)


if __name__ == "__main__":
    import sys
    app = QtWidgets.QApplication(sys.argv)
    widget = Ui_Widget()
    widget.show()
    sys.exit(app.exec_())
