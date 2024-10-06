from PyQt5 import QtCore, QtGui, QtWidgets
import csv
import sys
import time  
import traceback
from Hashmi import SortingAlgorithms
from PyQt5.QtWidgets import QApplication, QMessageBox, QWidget
from PyQt5.QtCore import QTimer


class MultiSortUI(QWidget):
    def __init__(self, parent=None):
        super(MultiSortUI, self).__init__(parent)
        self.setupUi()
    def setupUi(self):
        self.resize(824, 600)
        font = QtGui.QFont()
        font.setPointSize(12)
        self.setFont(font)
        
        self.setAutoFillBackground(False)
        self.label_2 = QtWidgets.QLabel(self)
        self.label_2.setGeometry(QtCore.QRect(280, 20, 241, 31))
        font = QtGui.QFont()



        self.scrapped_search = QtWidgets.QCheckBox("Search on Scrapped Data", self)
        self.scrapped_search.setGeometry(QtCore.QRect(300, 200, 150, 25))
        self.scrapped_search.setChecked(False)  
        self.scrapped_search.setStyleSheet("background-color: transparent;")  # or adjust as needed
        self.scrapped_search.stateChanged.connect(self.searchScrappedData)
        
        font.setPointSize(20)
        font.setBold(True)
        self.label_2.setFont(font)
        self.label_2.setObjectName("label_2")
        self.runtime = QtWidgets.QLabel(self)
        self.runtime.setGeometry(QtCore.QRect(40, 190, 81, 26))
        self.runtime.setStyleSheet("color:white;\n"
                                   "background-color:rgb(0, 85, 0);\n"
                                   "padding-left:6px;\n"
                                   "padding-right:6px;\n")
        self.runtime.setObjectName("runtime")
        self.AlgoComboBox = QtWidgets.QComboBox(self)
        
        font = QtGui.QFont()
        font.setPointSize(10)
        self.AlgoComboBox.setFont(font)
        self.AlgoComboBox.setObjectName("AlgoComboBox")
        self.AlgoComboBox.clear()
        self.AlgoComboBox.addItem("Merge Sort")
        self.AlgoComboBox.addItem("Bubble Sort")
        self.AlgoComboBox.addItem("Selection Sort")
        self.AlgoComboBox.addItem("Insertion Sort")
        self.AlgoComboBox.addItem("Hybrid Merge Sort")
        self.AlgoComboBox.addItem("Quick Sort")
        self.AlgoComboBox.addItem("Cycle Sort")
        self.AlgoComboBox.addItem("Tim Sort")
        self.AlgoComboBox.setGeometry(QtCore.QRect(380, 90, 150, 22))
        self.label = QtWidgets.QLabel(self)
        self.label.setGeometry(QtCore.QRect(200, 90, 181, 21))
        font = QtGui.QFont()
        font.setFamily("Impact")
        font.setPointSize(12)
        self.label.setFont(font)
        self.label.setObjectName("label")
        self.SortButton = QtWidgets.QPushButton(self)
        self.SortButton.setGeometry(QtCore.QRect(590, 190, 75, 26))
        font = QtGui.QFont()
        font.setPointSize(10)
        self.SortButton.setFont(font)
        self.SortButton.setCursor(QtGui.QCursor(QtCore.Qt.PointingHandCursor))
        self.SortButton.setStyleSheet("color:white;\n"
"background-color:rgb(0, 85, 0)")
        self.SortButton.setObjectName("SortButton")
        self.SortButton.clicked.connect(self.sortData)
        self.datatableWidget = QtWidgets.QTableWidget(self)
        self.datatableWidget.setGeometry(QtCore.QRect(30, 240, 721, 311))
        self.datatableWidget.setColumnCount(7)
        self.datatableWidget.setObjectName("datatableWidget")
        self.datatableWidget.setEditTriggers(QtWidgets.QAbstractItemView.NoEditTriggers)
        self.datatableWidget.setRowCount(0)
        item = QtWidgets.QTableWidgetItem()
        self.datatableWidget.setHorizontalHeaderItem(0, item)
        item = QtWidgets.QTableWidgetItem()
        self.datatableWidget.setHorizontalHeaderItem(1, item)
        item = QtWidgets.QTableWidgetItem()
        self.datatableWidget.setHorizontalHeaderItem(2, item)
        item = QtWidgets.QTableWidgetItem()
        self.datatableWidget.setHorizontalHeaderItem(3, item)
        item = QtWidgets.QTableWidgetItem()
        self.datatableWidget.setHorizontalHeaderItem(4, item)
        item = QtWidgets.QTableWidgetItem()
        self.datatableWidget.setHorizontalHeaderItem(5, item)
        item = QtWidgets.QTableWidgetItem()
        self.datatableWidget.setHorizontalHeaderItem(6, item)
        self.Title = QtWidgets.QCheckBox(self)
        self.Title.setGeometry(QtCore.QRect(160, 150, 67, 18))
        self.Title.setStyleSheet("background-color: transparent;") 
        font = QtGui.QFont()
        font.setPointSize(10)
        self.Title.setFont(font)
        self.Title.setObjectName("Title")
        self.Price = QtWidgets.QCheckBox(self)
        self.Price.setGeometry(QtCore.QRect(220, 150, 67, 18))
        self.Price.setStyleSheet("background-color: transparent;") 
        font = QtGui.QFont()
        font.setPointSize(10)
        self.Price.setFont(font)
        self.Price.setObjectName("Price")
        self.Location = QtWidgets.QCheckBox(self)
        self.Location.setGeometry(QtCore.QRect(280, 150, 67, 18))
        self.Location.setStyleSheet("background-color: transparent;") 
        font = QtGui.QFont()
        font.setPointSize(10)
        self.Location.setFont(font)
        self.Location.setObjectName("Location")
        self.City = QtWidgets.QCheckBox(self)
        self.City.setGeometry(QtCore.QRect(350, 150, 67, 18))
        self.City.setStyleSheet("background-color: transparent;") 
        font = QtGui.QFont()
        font.setPointSize(10)
        self.City.setFont(font)
        self.City.setObjectName("City")
        self.Beds = QtWidgets.QCheckBox(self)
        self.Beds.setGeometry(QtCore.QRect(410, 150, 67, 18))
        self.Beds.setStyleSheet("background-color: transparent;") 
        font = QtGui.QFont()
        font.setPointSize(10)
        self.Beds.setFont(font)
        self.Beds.setObjectName("Beds")
        self.Baths = QtWidgets.QCheckBox(self)
        self.Baths.setGeometry(QtCore.QRect(470, 150, 67, 18))
        self.Baths.setStyleSheet("background-color: transparent;") 
        font = QtGui.QFont()
        font.setPointSize(10)
        self.Baths.setFont(font)
        self.Baths.setObjectName("Baths")
        self.Area = QtWidgets.QCheckBox(self)
        self.Area.setGeometry(QtCore.QRect(530, 150, 67, 18))
        self.Area.setStyleSheet("background-color: transparent;") 
        font = QtGui.QFont()
        font.setPointSize(10)
        self.Area.setFont(font)
        self.Area.setObjectName("Area")
        self.data = [] 
        self.loadDataFromCSV('./Data/zameen_homes.csv') 

        self.retranslateUi()
        QtCore.QMetaObject.connectSlotsByName(self)
        self.checkbox_timestamps = {
            "Title": None,
            "Price": None,
            "Location": None,
            "City": None,
            "Beds": None,
            "Baths": None,
            "Area": None
        }

        
        self.Title.clicked.connect(lambda: self.checkbox_clicked("Title"))
        self.Price.clicked.connect(lambda: self.checkbox_clicked("Price"))
        self.Location.clicked.connect(lambda: self.checkbox_clicked("Location"))
        self.City.clicked.connect(lambda: self.checkbox_clicked("City"))
        self.Beds.clicked.connect(lambda: self.checkbox_clicked("Beds"))
        self.Baths.clicked.connect(lambda: self.checkbox_clicked("Baths"))
        self.Area.clicked.connect(lambda: self.checkbox_clicked("Area"))

    def checkbox_clicked(self, checkbox_name):
        self.checkbox_timestamps[checkbox_name] = time.time()
    def retranslateUi(self):
        _translate = QtCore.QCoreApplication.translate
        self.label_2.setText(_translate("MainWindow", "MultiColumn Sorting "))
        self.runtime.setText(_translate("MainWindow", "Runtime"))
        self.AlgoComboBox.setItemText(0, _translate("MainWindow", "Merge Sort"))
        self.AlgoComboBox.setItemText(1, _translate("MainWindow", "Bubble Sort"))
        self.AlgoComboBox.setItemText(2, _translate("MainWindow", "SelectionSort"))
        self.AlgoComboBox.setItemText(3, _translate("MainWindow", "Insertion Sort"))
        self.AlgoComboBox.setItemText(4, _translate("MainWindow", "Hybrid Merge Sort"))
        self.AlgoComboBox.setItemText(5, _translate("MainWindow", "Quick Sort"))
        self.AlgoComboBox.setItemText(6, _translate("MainWindow", "Cycle Sort"))
        self.AlgoComboBox.setItemText(7, _translate("MainWindow", "Tim Sort"))
        self.label.setText(_translate("MainWindow", "Select Sorting Algorithm: "))
        self.SortButton.setText(_translate("MainWindow", "Sort"))
        item = self.datatableWidget.horizontalHeaderItem(0)
        item.setText(_translate("MainWindow", "Title"))
        item = self.datatableWidget.horizontalHeaderItem(1)
        item.setText(_translate("MainWindow", "Price"))
        item = self.datatableWidget.horizontalHeaderItem(2)
        item.setText(_translate("MainWindow", "Location"))
        item = self.datatableWidget.horizontalHeaderItem(3)
        item.setText(_translate("MainWindow", "City"))
        item = self.datatableWidget.horizontalHeaderItem(4)
        item.setText(_translate("MainWindow", "Beds"))
        item = self.datatableWidget.horizontalHeaderItem(5)
        item.setText(_translate("MainWindow", "Baths"))
        item = self.datatableWidget.horizontalHeaderItem(6)
        item.setText(_translate("MainWindow", "Area"))
        self.Title.setText(_translate("MainWindow", "Title"))
        self.Price.setText(_translate("MainWindow", "Price"))
        self.Location.setText(_translate("MainWindow", "Location"))
        self.City.setText(_translate("MainWindow", "City"))
        self.Beds.setText(_translate("MainWindow", "Beds"))
        self.Baths.setText(_translate("MainWindow", "Baths"))
        self.Area.setText(_translate("MainWindow", "Area"))

    def get_sorted_checkboxes(self):
        
        clicked_checkboxes = {k: v for k, v in self.checkbox_timestamps.items() if v is not None}
        
        
        sorted_checkboxes = sorted(clicked_checkboxes, key=lambda k: clicked_checkboxes[k])
        
        return sorted_checkboxes
    

    def loadDataFromCSV(self, fileName):
        with open(fileName, newline='', encoding='utf-8') as csvfile:
            self.datatableWidget.setRowCount(0)
            reader = csv.reader(csvfile)
            header = next(reader)  
            self.data = []  
            for row in reader:
                self.data.append(row)
                rowPosition = self.datatableWidget.rowCount()
                self.datatableWidget.insertRow(rowPosition)
                for column, value in enumerate(row):
                    self.datatableWidget.setItem(rowPosition, column, QtWidgets.QTableWidgetItem(value))
    def show_message_box(self,title,message):
            msg_box = QMessageBox()

            msg_box.setWindowTitle(title)
            msg_box.setText(message)
            msg_box.setIcon(QMessageBox.Information)

            msg_box.setStandardButtons(QMessageBox.Ok)
            msg_box.setDefaultButton(QMessageBox.Ok)

            result = msg_box.exec_()


    def sortData(self):
        

        try:
            selected_attributes = []
            selected_algo = self.AlgoComboBox.currentText()
            sorted_checkboxes = self.get_sorted_checkboxes()

            for checkbox_name in sorted_checkboxes:
                checkbox = self.get_checkbox_by_name(checkbox_name)
                if checkbox and checkbox.isChecked():
                    checkbox_index = self.getAttributeIndex(checkbox_name)
                    if checkbox_index != -1:
                        selected_attributes.append(checkbox_index)
            

            if len(selected_attributes) == 0:
                self.show_message_box("Error", "No attribute selected for sorting.")
            else:
                self.runtime.setGeometry(QtCore.QRect(40, 190, 120, 26))
                #    self.runtime.setGeometry(QtCore.QRect(40, 190, 81, 26))
                self.runtime.setText(f"Runtime: Sorting...")
                QtWidgets.QApplication.processEvents()
            
                array_to_sort = [list(row) for row in self.data]

                start_time = time.time()
                array_to_sort = []
                for row_index, row in enumerate(self.data):
                    new_row = list(row)
                    for attribute_index in selected_attributes:
                        if attribute_index == 4 or attribute_index == 5:
                            new_row[attribute_index] = int(row[attribute_index])
                        if attribute_index == 1:
                            new_row[attribute_index] = self.PriceConverter(row[attribute_index])
                        if attribute_index == 6:
                            new_row[attribute_index] = self.AreaConverter(row[attribute_index])

                    
                    array_to_sort.append(new_row)
                    start_time=time.time()
                
                for i in range (len(selected_attributes)-1,-1,-1):
                    attribute_index=selected_attributes[i]
                    array_to_sort = self.sort_by_attribute(array_to_sort, attribute_index, selected_algo)

                end_time = time.time()
                runtime = (end_time - start_time) * 1000
                self.runtime.setGeometry(QtCore.QRect(40, 190, 180, 26))
                self.runtime.setText(f"Runtime: {runtime:.2f} ms")

                self.displaySortedArray(array_to_sort)
                self.show_message_box("Success", "Data is sorted successfully.")
                self.uncheck_all_checkboxes()

        except Exception as e:
            error_message = str(e)
            self.runtime.setText(f"Error: {error_message}")
            print("An error occurred:", error_message)
            print(traceback.format_exc())
    def get_checkbox_by_name(self, name):
        
        checkbox_mapping = {
            'Title': self.Title,
            'Price': self.Price,
            'Location': self.Location,
            'City': self.City,
            'Beds': self.Beds,
            'Baths': self.Baths,
            'Area': self.Area,
            
            
        }
        return checkbox_mapping.get(name)
    def sort_by_attribute(self, array_to_sort, attribute_index, selected_algo):
        
        array_with_values = [(row[attribute_index], row) for row in array_to_sort]

        values_to_sort = [tup[0] for tup in array_with_values]

        if selected_algo == 'Merge Sort':
            SortingAlgorithms.MergeSort(values_to_sort, 0, len(values_to_sort) - 1)
        elif selected_algo == 'Hybrid Merge Sort':
            SortingAlgorithms.HybridMergeSort(values_to_sort, 0, len(values_to_sort) - 1)
        elif selected_algo == 'Bubble Sort':
            SortingAlgorithms.BubbleSort(values_to_sort, 0, len(values_to_sort))
        elif selected_algo == 'Selection Sort':
            SortingAlgorithms.SelectionSort(values_to_sort, 0, len(values_to_sort))
        elif selected_algo == 'Insertion Sort':
            SortingAlgorithms.InsertionSort(values_to_sort, 0, len(values_to_sort))
        elif selected_algo == 'Quick Sort':
            SortingAlgorithms.QuickSort(values_to_sort, 0, len(values_to_sort) - 1)
        elif selected_algo == 'Cycle Sort':
            SortingAlgorithms.CycleSort(values_to_sort)
        elif selected_algo == 'Tim Sort':
            SortingAlgorithms.TimSort(values_to_sort)

        
        sorted_array = [row for _, row in sorted(array_with_values, key=lambda x: x[0])]
        return sorted_array

    def searchScrappedData(self, state):        
        if state == QtCore.Qt.Checked:
            self.loadDataFromCSV('./Data/scraped_homes.csv')
        else:
            self.loadDataFromCSV('./Data/zameen_homes.csv')


    def getAttributeIndex(self, attribute):
        attribute_map = {
            "Title": 0,
            "Price": 1,
            "Location": 2,
            "City": 3,
            "Beds": 4,
            "Baths": 5,
            "Area": 6
        }
        return attribute_map.get(attribute, -1)
    

    def displaySortedArray(self, sorted_data):
        self.datatableWidget.setRowCount(0)  
        existing_rows = set() 

        for row in sorted_data:
            row_tuple = tuple(row) 

            if row_tuple not in existing_rows:  
                existing_rows.add(row_tuple)
                rowPosition = self.datatableWidget.rowCount()
                self.datatableWidget.insertRow(rowPosition)

                for column, value in enumerate(row):
                    
                    if column == 1 and isinstance(value, (int, float)):  
                        value = self.reversePriceConverter(value)

                    elif column == 6 and isinstance(value, (int, float)):  
                        value = self.reverseAreaConverter(value)


                    if column in (4, 5) and isinstance(value, int):
                        value = str(value)
                    
                    self.datatableWidget.setItem(rowPosition, column, QtWidgets.QTableWidgetItem(str(value)))
    
    def CanSort(self,attributename,algorithm):
        if((attributename!="Beds" and attributename!="Baths") and(algorithm=="Counting Sort" or algorithm=="Radix Sort" or algorithm=="PigeonHole Sort")):
            return False
        elif((attributename!="Area"  and attributename!="Beds" and attributename!="Baths")and(algorithm=="Bucket Sort")):
            return False
        return True
    
    def PriceConverter(self, price):
        if "Crore" in price:
            numeric_value = float(price.replace("Crore", "").strip())
            return numeric_value * 10000000
        elif "Arab" in price:
            numeric_value = float(price.replace("Arab", "").strip())
            return numeric_value * 1000000000
        elif "Lakh" in price:
            numeric_value = float(price.replace("Lakh", "").strip())
            return numeric_value * 100000
        elif "Thousand" in price:
            numeric_value = float(price.replace("Thousand", "").strip())
            return numeric_value * 1000
        else:
            return float(price)
    
    def reversePriceConverter(self, price):
        if price >= 1000000000:
            converted_value = price / 1000000000
            return f"{converted_value:.2f} Arab"
        elif price >= 10000000:
            converted_value = price / 10000000
            return f"{converted_value:.2f} Crore"
        elif price >= 100000:
            converted_value = price / 100000
            return f"{converted_value:.2f} Lakh"
        elif price >= 1000:
            converted_value = price / 1000
            return f"{converted_value:.2f} Thousand"
        else:
            return str(price)
        
    def AreaConverter(self, Area):
        if "Kanal" in Area:
            numeric_value = float(Area.replace("Kanal", "").strip())
            return numeric_value * 20
        elif "Marla" in Area:
            numeric_value = float(Area.replace("Marla", "").strip())
            return numeric_value
        else:
            return float(Area)
        
    def reverseAreaConverter(self, area):
        if area >= 20:
            kanal_value = area / 20
            return f"{kanal_value:.1f} Kanal"
        else: 
            return f"{area:.1f} Marla"
    def get_all_checkboxes(self):
        
        return [
            self.Title, 
            self.Price,
            self.Location,
            self.City,
            self.Beds,
            self.Baths,
            self.Area,
            
        ]
    def uncheck_all_checkboxes(self):
        
        checkboxes = self.get_all_checkboxes() 
        for checkbox in checkboxes:
            checkbox.setChecked(False)
if __name__ == "__main__":
    app = QApplication(sys.argv)
    window = MultiSortUI()
    window.show()
    sys.exit(app.exec_())
