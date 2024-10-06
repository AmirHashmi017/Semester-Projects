import pandas as pd
from PyQt5 import QtCore, QtGui, QtWidgets

class SearchUI(QtWidgets.QWidget): 
    def __init__(self, parent=None):
        super(SearchUI, self).__init__(parent)
        self.setupUi()

    def setupUi(self):
        box_h = 25  # const height
        box_w = 190  # const weight

        self.setObjectName("MainWidget")
        self.resize(800, 600)
        self.centralwidget = QtWidgets.QWidget(self)
        self.centralwidget.setObjectName("centralwidget")

        self.label = QtWidgets.QLabel(self.centralwidget)
        self.label.setGeometry(QtCore.QRect(260, 20, 200, 70))
        self.label.setObjectName("label")
        self.label.setStyleSheet("font-weight: bold;font-size: 15px;") 
        self.label.setText("Search Zameen Homes")

        self.label_2 = QtWidgets.QLabel(self.centralwidget)
        self.label_2.setGeometry(QtCore.QRect(220, 90, 70, 30))  
        self.label_2.setObjectName("label_2")
        self.label_2.setText("Search")

        self.lineEdit = QtWidgets.QLineEdit(self.centralwidget)
        self.lineEdit.setGeometry(QtCore.QRect(290, 95, box_w, box_h))
        self.lineEdit.setObjectName("lineEdit")

        self.label_3 = QtWidgets.QLabel(self.centralwidget)
        self.label_3.setGeometry(QtCore.QRect(220, 138, 60, 15))  
        self.label_3.setObjectName("label_3")
        self.label_3.setText("Attribute")

        self.comboBox = QtWidgets.QComboBox(self.centralwidget)
        self.comboBox.setGeometry(QtCore.QRect(290, 135, box_w, box_h))  
        self.comboBox.setObjectName("comboBox")

        self.filterComboBox = QtWidgets.QComboBox(self.centralwidget)
        self.filterComboBox.setGeometry(QtCore.QRect(290, 170, box_w, box_h))  
        self.filterComboBox.setObjectName("filterComboBox")
        self.filterComboBox.addItems(["Starts with", "Ends with", "Contains"]) 

        self.label_filter = QtWidgets.QLabel(self.centralwidget)  
        self.label_filter.setGeometry(QtCore.QRect(230, 173, 45, 15))  
        self.label_filter.setObjectName("label_filter")
        self.label_filter.setText("Filter")

        self.findButton = QtWidgets.QPushButton("Find", self.centralwidget)
        self.findButton.setGeometry(QtCore.QRect(335, 215, 75, 25))  
        self.findButton.setStyleSheet("font-weight: bold;") 
        self.findButton.clicked.connect(self.findLocations)

        self.advancedFilterCheckbox = QtWidgets.QCheckBox("Advanced Filters", self.centralwidget)
        self.advancedFilterCheckbox.setGeometry(QtCore.QRect(550, 200, 150, 25))
        self.advancedFilterCheckbox.setChecked(False)  
        self.advancedFilterCheckbox.setStyleSheet("background-color: transparent;")  # or adjust as needed
        self.advancedFilterCheckbox.stateChanged.connect(self.toggleAdvancedFilters)  


        self.scrapped_search = QtWidgets.QCheckBox("Search on Scrapped Data", self.centralwidget)
        self.scrapped_search.setGeometry(QtCore.QRect(550, 225, 150, 25))
        self.scrapped_search.setChecked(False)  
        self.scrapped_search.setStyleSheet("background-color: transparent;")  # or adjust as needed
        self.scrapped_search.stateChanged.connect(self.searchScrappedData)  

        self.df = pd.read_csv('./Data/zameen_homes.csv', usecols=range(7))

        # adnv filter widgets
        self.advanced_filter_widgets = []
        columns = [col for col in self.df.columns]
        for i, column in enumerate(columns):
            label = QtWidgets.QLabel(self.centralwidget)
            if i > 3:
                label.setGeometry(QtCore.QRect(320, -70 + (i * 40), 100, 30))
            else:
                label.setGeometry(QtCore.QRect(50, 90 + (i * 40), 100, 30))
            label.setText(column)
            line_edit = QtWidgets.QLineEdit(self.centralwidget)
            if i > 3:
                line_edit.setGeometry(QtCore.QRect(370, -70 + (i * 40), box_w, box_h))
            else:
                line_edit.setGeometry(QtCore.QRect(120, 90 + (i * 40), box_w, box_h))
            self.advanced_filter_widgets.append((label, line_edit))
            label.hide()
            line_edit.hide()
            if i == 6:
                labelCM = QtWidgets.QLabel(self.centralwidget)
                labelCM.setGeometry(QtCore.QRect(570, 92, 60, 15))  
                labelCM.setObjectName("labelCM")
                labelCM.setText("Operator")

                advcomboBox = QtWidgets.QComboBox(self.centralwidget)
                advcomboBox.setGeometry(QtCore.QRect(640, 90, 100, 25))  
                advcomboBox.setObjectName("advcomboBox")
                advcomboBox.addItems(["AND", "OR", "NOT"]) 

                self.advanced_filter_widgets.append((labelCM, advcomboBox))
                labelCM.hide()
                advcomboBox.hide()

        # advnc search btn
        self.advancedSearchButton = QtWidgets.QPushButton("Search", self.centralwidget)
        self.advancedSearchButton.setGeometry(QtCore.QRect(400, 207, 75, 30))

        self.advancedSearchButton.setStyleSheet("font-weight: bold;")
        self.advancedSearchButton.clicked.connect(self.advancedSearch)
        self.advancedSearchButton.hide()


        self.resultsTable = QtWidgets.QTableWidget(self.centralwidget)
        self.resultsTable.setGeometry(QtCore.QRect(50, 260, 700, 300))  
        self.resultsTable.setObjectName("resultsTable")
        self.resultsTable.setColumnCount(len(self.df.columns))  
        self.resultsTable.setHorizontalHeaderLabels([col for col in self.df.columns])

        # table read-only
        self.resultsTable.setEditTriggers(QtWidgets.QAbstractItemView.NoEditTriggers)

        self.resultsTable.itemClicked.connect(self.onItemClicked)

        self.comboBox.addItems(columns)

        self.displayData(self.df.head(1000))


    def retranslateUi(self):
        _translate = QtCore.QCoreApplication.translate
        self.setWindowTitle(_translate("SearchZameen", "SearchZameen"))
        self.label.setText(_translate("SearchZameen", "Search Zameen Houses"))  
        self.label_2.setText(_translate("SearchZameen", "Search Box"))
        self.label_3.setText(_translate("SearchZameen", "Field"))
        self.label_filter.setText(_translate("SearchZameen", "Filter"))

    def displayData(self, data, limit=None):
        self.resultsTable.setRowCount(0)  

        if limit:
            data = data.head(limit) # for first time loading of data

        self.resultsTable.setRowCount(len(data))

        for row_index in range(len(data)):
            for column_index in range(len(data.columns)):
                item = QtWidgets.QTableWidgetItem(str(data.iat[row_index, column_index]))
                self.resultsTable.setItem(row_index, column_index, item)

    def toggleAdvancedFilters(self, state):
        widgets = [self.lineEdit, self.comboBox, self.label_2, self.label_3, self.filterComboBox, self.label_filter, self.findButton]
        if state == QtCore.Qt.Unchecked:  
            for label, line_edit in self.advanced_filter_widgets:
                label.hide()
                line_edit.hide()
            self.advancedSearchButton.hide()
            for widget in widgets:
                widget.show()
        else:  
            for label, line_edit in self.advanced_filter_widgets:
                label.show()
                line_edit.show()
            self.advancedSearchButton.show()
            for widget in widgets:
                widget.hide()

    def searchScrappedData(self, state):        
        if state == QtCore.Qt.Checked:
            self.df = pd.read_csv('./Data/scraped_homes.csv', usecols=range(7))
        else:
            self.df = pd.read_csv('./Data/zameen_homes.csv', usecols=range(7))

        self.displayData(self.df.head(1000))

    def advancedSearch(self):
        search_conditions = []
        operator = None
    
        for i, (label, widget) in enumerate(self.advanced_filter_widgets):
            if isinstance(widget, QtWidgets.QComboBox) and widget.objectName() == "advcomboBox":
                operator = widget.currentText()
            else:
                search_term = widget.text().strip()
                if search_term:
                    column_name = self.df.columns[i]  
                    condition = self.df[column_name].astype(str).str.contains(search_term, case=False, na=False)
                    search_conditions.append((condition, column_name, search_term))
    
        if operator == "AND":
            if search_conditions:
                combined_condition = pd.Series([True] * len(self.df))
                for condition, _, _ in search_conditions:
                    combined_condition = combined_condition & condition
                results = self.df[combined_condition]
            else:
                results = pd.DataFrame()  
    
        elif operator == "OR":
            if search_conditions:
                combined_condition = pd.Series([False] * len(self.df))
                for condition, _, _ in search_conditions:
                    combined_condition = combined_condition | condition
                results = self.df[combined_condition]
            else:
                results = pd.DataFrame() 
    
        elif operator == "NOT":
            if search_conditions:
                combined_condition = pd.Series([False] * len(self.df))
                for condition, _, _ in search_conditions:
                    combined_condition = combined_condition | condition
                results = self.df[~combined_condition]
            else:
                results = self.df  
    
        else:
            QtWidgets.QMessageBox.warning(None, "Invalid Operator", "Please select a valid operator.")
            return
    
        if results.empty:
            QtWidgets.QMessageBox.warning(None, "No Results", "No records found.")
        else:
            self.displayData(results)

    def findLocations(self):
        search_term = self.lineEdit.text().strip()  
        selected_field = self.comboBox.currentText()
        filter_option = self.filterComboBox.currentText() if self.filterComboBox.isVisible() else "Contains"

        if selected_field in self.df.columns:
            if filter_option == "Starts with":
                results = self.df[self.df[selected_field].astype(str).str.startswith(search_term, na=False)]
            elif filter_option == "Ends with":
                results = self.df[self.df[selected_field].astype(str).str.endswith(search_term, na=False)]
            elif filter_option == "Contains":
                results = self.df[self.df[selected_field].astype(str).str.contains(search_term, na=False, case=False)]

            if results.empty:
                QtWidgets.QMessageBox.warning(None, "No Results", "No records found.")
            else:
                self.displayData(results)
        else:
            QtWidgets.QMessageBox.warning(None, "Invalid Field", "Invalid field selected.")
            self.resultsTable.setRowCount(0)  

    # set text from table to line edit
    def onItemClicked(self, item):
        self.lineEdit.setText(item.text())
        
        column = item.column()  
        
        if self.resultsTable.horizontalHeaderItem(column).text() == "Title":
            self.advanced_filter_widgets[0][1].setText(item.text())  
        elif self.resultsTable.horizontalHeaderItem(column).text() == "Price":
            self.advanced_filter_widgets[1][1].setText(item.text())  
        elif self.resultsTable.horizontalHeaderItem(column).text() == "Location":
            self.advanced_filter_widgets[2][1].setText(item.text())  
        elif self.resultsTable.horizontalHeaderItem(column).text() == "City":
            self.advanced_filter_widgets[3][1].setText(item.text())  
        elif self.resultsTable.horizontalHeaderItem(column).text() == "Beds":
            self.advanced_filter_widgets[4][1].setText(item.text())  
        elif self.resultsTable.horizontalHeaderItem(column).text() == "Baths":
            self.advanced_filter_widgets[5][1].setText(item.text())  
        elif self.resultsTable.horizontalHeaderItem(column).text() == "Area":
            self.advanced_filter_widgets[6][1].setText(item.text())  

if __name__ == "__main__":
    import sys
    app = QtWidgets.QApplication(sys.argv)
    window = SearchUI()  # Now using QWidget
    window.show()  # QWidget does not need `MainWindow.show()`
    sys.exit(app.exec_())
