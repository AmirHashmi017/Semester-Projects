from PyQt5 import QtCore, QtGui, QtWidgets
from Sherri.Scrap_main import ScrapUI 
from Sherri.Bonus import Ui_Widget 
from Moon.search import SearchUI 
from Hashmi.Sorting_App import SortUI
from Hashmi.Sorting_App import SortUI  
from Hashmi.MultiColumnSorting import MultiSortUI
from Hashmi import SortingAlgorithms
import subprocess

class Ui_MainWindow(object):
    def setupUi(self, MainWindow):
        MainWindow.setObjectName("MainWindow")
        # MainWindow.resize(796, 600)  # old size

        MainWindow.resize(1000, 680)
        
        # center the window
        screen_geometry = QtWidgets.QDesktopWidget().screenGeometry()
        x = (screen_geometry.width() - MainWindow.width()) // 2
        y = (screen_geometry.height() - MainWindow.height()) // 2
        MainWindow.move(x, y)
        
        MainWindow.setStyleSheet("""
    * {
        background-color: #ffffff;  /* Main background color */
        color: #333333;  /* Default text color */
        font-family: Arial, sans-serif;
    }
    #centralwidget {
        background-color: #f9f9f9;  /* Light gray background for central widget */
    }
    #LeftMainContainer {
        background-color: #e0f7e0;  /* Light green background for left container */
    }
    #LeftMainContainer QPushButton {
        border: none;
        background-color: transparent;  /* Transparent background for buttons */
        color: #333333;  /* Dark text color for buttons */
        text-align: left;
        padding: 10px 20px;
        font-size: 14px;
    }
    #LeftMainContainer QPushButton:hover {
        background-color: #c8e6c9;  /* Lighter green on hover */
    }
    #LeftMainContainer QPushButton:pressed {
        background-color: #a5d6a7;  /* Medium green when pressed */
    }
    #LeftMainContainer QPushButton:focus {
        outline: none;  /* Remove outline */
        background-color: #81c784;  /* Darker green on focus */
    }
    #MainMenu {
        background-color: #ffffff;  /* White background for the main menu */
        color: #333333;  /* Dark text color */
    }
    QLabel {
        color: #333333;  /* Dark text for labels */
        font-size: 14px;
    }
    QFrame {
        background-color: #f9f9f9;  /* Light gray for frames */
    }
    QPushButton {
        border-radius: 5px;  /* Rounded corners for buttons */
        background-color: #4caf50;  /* Green background for buttons */
        color: #ffffff;  /* White text for buttons */
        padding: 8px 15px;
    }
    QPushButton:hover {
        background-color: #66bb6a;  /* Lighter green on hover */
    }
    QPushButton:pressed {
        background-color: #388e3c;  /* Darker green when pressed */
    }
    QStatusBar {
        background-color: #f9f9f9;  /* Light gray for status bar */
        color: #333333;  /* Dark text for status bar */
    }
""")

        self.centralwidget = QtWidgets.QWidget(MainWindow)
        self.centralwidget.setObjectName("centralwidget")
        self.horizontalLayout = QtWidgets.QHBoxLayout(self.centralwidget)
        self.horizontalLayout.setContentsMargins(0, 0, 0, 0)
        self.horizontalLayout.setSpacing(0)
        self.horizontalLayout.setObjectName("horizontalLayout")
        self.LeftSideBar = QtWidgets.QWidget(self.centralwidget)
        self.LeftSideBar.setObjectName("LeftSideBar")
        self.verticalLayout = QtWidgets.QVBoxLayout(self.LeftSideBar)
        self.verticalLayout.setContentsMargins(0, 0, 0, 0)
        self.verticalLayout.setSpacing(0)
        self.verticalLayout.setObjectName("verticalLayout")
        self.LeftMainContainer = QtWidgets.QWidget(self.LeftSideBar)
        self.LeftMainContainer.setObjectName("LeftMainContainer")
        self.verticalLayout_2 = QtWidgets.QVBoxLayout(self.LeftMainContainer)
        self.verticalLayout_2.setContentsMargins(0, 0, 0, 0)
        self.verticalLayout_2.setSpacing(0)
        self.verticalLayout_2.setObjectName("verticalLayout_2")
        self.frame = QtWidgets.QFrame(self.LeftMainContainer)
        self.frame.setFrameShape(QtWidgets.QFrame.StyledPanel)
        self.frame.setFrameShadow(QtWidgets.QFrame.Raised)
        self.frame.setObjectName("frame")
        self.horizontalLayout_2 = QtWidgets.QHBoxLayout(self.frame)
        self.horizontalLayout_2.setContentsMargins(0, 0, 0, 0)
        self.horizontalLayout_2.setSpacing(0)
        self.horizontalLayout_2.setObjectName("horizontalLayout_2")
        self.pushButton = QtWidgets.QPushButton(self.frame)
        self.pushButton.setText("")
        icon = QtGui.QIcon()
        icon.addPixmap(QtGui.QPixmap(":/Icons/Icons/align-justify.svg"), QtGui.QIcon.Normal, QtGui.QIcon.Off)
        icon.pixmap(24, 24).fill(QtGui.QColor(255, 255, 255))
        self.pushButton.setIcon(icon)
        self.pushButton.setIconSize(QtCore.QSize(24, 24))
        self.pushButton.setObjectName("pushButton")
        self.horizontalLayout_2.addWidget(self.pushButton)
        self.verticalLayout_2.addWidget(self.frame, 0, QtCore.Qt.AlignTop)
        self.frame_2 = QtWidgets.QFrame(self.LeftMainContainer)
        sizePolicy = QtWidgets.QSizePolicy(QtWidgets.QSizePolicy.Preferred, QtWidgets.QSizePolicy.Preferred)
        sizePolicy.setHorizontalStretch(0)
        sizePolicy.setVerticalStretch(0)
        sizePolicy.setHeightForWidth(self.frame_2.sizePolicy().hasHeightForWidth())
        self.frame_2.setSizePolicy(sizePolicy)
        self.frame_2.setFrameShape(QtWidgets.QFrame.StyledPanel)
        self.frame_2.setFrameShadow(QtWidgets.QFrame.Raised)
        self.frame_2.setObjectName("frame_2")
        self.verticalLayout_3 = QtWidgets.QVBoxLayout(self.frame_2)
        self.verticalLayout_3.setContentsMargins(0, -1, 0, -1)
        self.verticalLayout_3.setObjectName("verticalLayout_3")
        self.HomeBtn = QtWidgets.QPushButton(self.frame_2)
        icon1 = QtGui.QIcon()
        icon1.addPixmap(QtGui.QPixmap(":/Icons/Icons/home.svg"), QtGui.QIcon.Normal, QtGui.QIcon.Off)
        self.HomeBtn.setIcon(icon1)
        self.HomeBtn.setIconSize(QtCore.QSize(24, 24))
        self.HomeBtn.setObjectName("HomeBtn")
        self.verticalLayout_3.addWidget(self.HomeBtn)
        self.ScrapingBtn = QtWidgets.QPushButton(self.frame_2)
        icon2 = QtGui.QIcon()
        icon2.addPixmap(QtGui.QPixmap(":/Icons/Icons/activity.svg"), QtGui.QIcon.Normal, QtGui.QIcon.Off)
        self.ScrapingBtn.setIcon(icon2)
        self.ScrapingBtn.setIconSize(QtCore.QSize(24, 24))
        self.ScrapingBtn.setObjectName("ScrapingBtn")
        self.verticalLayout_3.addWidget(self.ScrapingBtn)
        self.DataListing = QtWidgets.QPushButton(self.frame_2)
        icon3 = QtGui.QIcon()
        icon3.addPixmap(QtGui.QPixmap(":/Icons/Icons/clipboard.svg"), QtGui.QIcon.Normal, QtGui.QIcon.Off)
        self.DataListing.setIcon(icon3)
        self.DataListing.setIconSize(QtCore.QSize(24, 24))
        self.DataListing.setObjectName("DataListing")
        self.verticalLayout_3.addWidget(self.DataListing)
        self.verticalLayout_2.addWidget(self.frame_2, 0, QtCore.Qt.AlignTop)
        spacerItem = QtWidgets.QSpacerItem(20, 40, QtWidgets.QSizePolicy.Minimum, QtWidgets.QSizePolicy.Expanding)
        self.verticalLayout_2.addItem(spacerItem)
        self.frame_3 = QtWidgets.QFrame(self.LeftMainContainer)
        self.frame_3.setFrameShape(QtWidgets.QFrame.StyledPanel)
        self.frame_3.setFrameShadow(QtWidgets.QFrame.Raised)
        self.frame_3.setObjectName("frame_3")
        self.verticalLayout_4 = QtWidgets.QVBoxLayout(self.frame_3)
        self.verticalLayout_4.setContentsMargins(0, -1, 0, -1)
        self.verticalLayout_4.setObjectName("verticalLayout_4")
        self.ViewCSVBtn = QtWidgets.QPushButton(self.frame_3)
        icon4 = QtGui.QIcon()
        icon4.addPixmap(QtGui.QPixmap(":/Icons/Icons/file.svg"), QtGui.QIcon.Normal, QtGui.QIcon.Off)
        self.ViewCSVBtn.setIcon(icon4)
        self.ViewCSVBtn.setIconSize(QtCore.QSize(24, 24))
        self.ViewCSVBtn.setObjectName("ViewCSVBtn")
        self.verticalLayout_4.addWidget(self.ViewCSVBtn)
        self.InfoBtn = QtWidgets.QPushButton(self.frame_3)
        icon5 = QtGui.QIcon()
        icon5.addPixmap(QtGui.QPixmap(":/Icons/Icons/info.svg"), QtGui.QIcon.Normal, QtGui.QIcon.Off)
        self.InfoBtn.setIcon(icon5)
        self.InfoBtn.setIconSize(QtCore.QSize(24, 24))
        self.InfoBtn.setObjectName("DataSorting")
        self.verticalLayout_4.addWidget(self.InfoBtn)
        self.CloseAppBtn = QtWidgets.QPushButton(self.frame_3)
        icon6 = QtGui.QIcon()
        icon6.addPixmap(QtGui.QPixmap(":/Icons/Icons/x.svg"), QtGui.QIcon.Normal, QtGui.QIcon.Off)
        self.CloseAppBtn.setIcon(icon6)
        self.CloseAppBtn.setIconSize(QtCore.QSize(24, 24))
        self.CloseAppBtn.setObjectName("CloseAppBtn")
        self.verticalLayout_4.addWidget(self.CloseAppBtn)
        self.verticalLayout_2.addWidget(self.frame_3, 0, QtCore.Qt.AlignBottom)
        self.verticalLayout.addWidget(self.LeftMainContainer)
        self.horizontalLayout.addWidget(self.LeftSideBar, 0, QtCore.Qt.AlignLeft)
        self.MainMenu = QtWidgets.QWidget(self.centralwidget)
        sizePolicy = QtWidgets.QSizePolicy(QtWidgets.QSizePolicy.Expanding, QtWidgets.QSizePolicy.Preferred)
        sizePolicy.setHorizontalStretch(0)
        sizePolicy.setVerticalStretch(0)
        sizePolicy.setHeightForWidth(self.MainMenu.sizePolicy().hasHeightForWidth())
        self.MainMenu.setSizePolicy(sizePolicy)

        self.MainMenu.setObjectName("MainMenu")
        self.verticalLayout_6 = QtWidgets.QVBoxLayout(self.MainMenu)
        self.verticalLayout_6.setObjectName("verticalLayout_6")
        self.frame_7 = QtWidgets.QFrame(self.MainMenu)
        self.frame_7.setFrameShape(QtWidgets.QFrame.StyledPanel)
        self.frame_7.setFrameShadow(QtWidgets.QFrame.Raised)
        self.frame_7.setObjectName("frame_7")
        self.verticalLayout_7 = QtWidgets.QVBoxLayout(self.frame_7)
        self.verticalLayout_7.setObjectName("verticalLayout_7")
        self.widget_2 = QtWidgets.QWidget(self.frame_7)
        sizePolicy = QtWidgets.QSizePolicy(QtWidgets.QSizePolicy.Expanding, QtWidgets.QSizePolicy.Expanding)
        sizePolicy.setHorizontalStretch(0)
        sizePolicy.setVerticalStretch(0)
        sizePolicy.setHeightForWidth(self.widget_2.sizePolicy().hasHeightForWidth())
        self.widget_2.setSizePolicy(sizePolicy)
        self.widget_2.setObjectName("widget_2")
        self.verticalLayout_8 = QtWidgets.QVBoxLayout(self.widget_2)
        self.verticalLayout_8.setObjectName("verticalLayout_8")
        self.stackedWidget_2 = QtWidgets.QStackedWidget(self.widget_2)
        self.stackedWidget_2.setObjectName("stackedWidget_2")
        self.page_3 = QtWidgets.QWidget()
        self.page_3.setObjectName("page_3")
        self.label_4 = QtWidgets.QLabel(self.page_3)
        self.label_4.setGeometry(QtCore.QRect(40, 70, 47, 13))
        self.label_4.setObjectName("label_4")
        self.stackedWidget_2.addWidget(self.page_3)
        self.page_4 = QtWidgets.QWidget()
        self.page_4.setObjectName("page_4")
        self.label_6 = QtWidgets.QLabel(self.page_4)
        self.label_6.setGeometry(QtCore.QRect(140, 100, 47, 13))
        self.label_6.setObjectName("label_6")
        self.stackedWidget_2.addWidget(self.page_4)
        self.page_5 = QtWidgets.QWidget()
        self.page_5.setObjectName("page_5")
        self.label_7 = QtWidgets.QLabel(self.page_5)
        self.label_7.setGeometry(QtCore.QRect(190, 110, 47, 13))
        self.label_7.setObjectName("label_7")
        self.stackedWidget_2.addWidget(self.page_5)
        self.verticalLayout_8.addWidget(self.stackedWidget_2)
        self.verticalLayout_7.addWidget(self.widget_2)
        self.verticalLayout_6.addWidget(self.frame_7)
        self.horizontalLayout.addWidget(self.MainMenu)
        MainWindow.setCentralWidget(self.centralwidget)
        self.menubar = QtWidgets.QMenuBar(MainWindow)
        self.menubar.setGeometry(QtCore.QRect(0, 0, 796, 21))
        self.menubar.setObjectName("menubar")
        MainWindow.setMenuBar(self.menubar)
        self.statusbar = QtWidgets.QStatusBar(MainWindow)
        self.statusbar.setObjectName("statusbar")
        MainWindow.setStatusBar(self.statusbar)

        self.retranslateUi(MainWindow)
        QtCore.QMetaObject.connectSlotsByName(MainWindow)

    def retranslateUi(self, MainWindow):
        _translate = QtCore.QCoreApplication.translate
        MainWindow.setWindowTitle(_translate("MainWindow", "MainWindow"))
        self.HomeBtn.setText(_translate("MainWindow", "Bonus Task"))
        self.ScrapingBtn.setText(_translate("MainWindow", "Scraping"))
        self.DataListing.setText(_translate("MainWindow", "Data Listing"))
        self.ViewCSVBtn.setText(_translate("MainWindow", "MutiColumn Sorting"))
        self.InfoBtn.setText(_translate("MainWindow", "Data Sorting"))
        self.CloseAppBtn.setText(_translate("MainWindow", "Close App"))
        self.label_4.setText(_translate("MainWindow", "Home"))
        self.label_6.setText(_translate("MainWindow", "Scraping"))
        self.label_7.setText(_translate("MainWindow", "Data Listing"))
        self.HomeBtn.clicked.connect(self.open_bonus_page)
        self.ScrapingBtn.clicked.connect(self.open_scrap_page)
        self.DataListing.clicked.connect(self.open_search_page)
        self.ViewCSVBtn.clicked.connect(self.open_multi_sort_page)
        self.InfoBtn.clicked.connect(self.open_sort_page)
        self.pushButton.clicked.connect(self.toggleSidebar)
        self.CloseAppBtn.clicked.connect(self.CloseApp)
        self.is_sidebar_expanded = True  
    def CloseApp(self):
        sys.exit(0)
    def toggleSidebar(self):
        if self.is_sidebar_expanded:
            self.LeftSideBar.setFixedWidth(60)
            self.is_sidebar_expanded = False
        else:
            self.LeftSideBar.setFixedWidth(200) 
            self.is_sidebar_expanded = True
            
    def open_bonus_page(self):
        if not hasattr(self, 'ui_bonus_page'):
            self.ui_bonus_page = Ui_Widget()  
        
        self.stackedWidget_2.addWidget(self.ui_bonus_page) 
        self.stackedWidget_2.setCurrentWidget(self.ui_bonus_page)
    
    def open_scrap_page(self):
        if not hasattr(self, 'ui_other_page'):
            self.ui_other_page = ScrapUI()  
        
        self.stackedWidget_2.addWidget(self.ui_other_page) 
        self.stackedWidget_2.setCurrentWidget(self.ui_other_page)
    
    def open_search_page(self):
        if not hasattr(self, 'ui_search_page'):
            self.ui_search_page = SearchUI()  
        
        self.stackedWidget_2.addWidget(self.ui_search_page) 
        self.stackedWidget_2.setCurrentWidget(self.ui_search_page)

    def open_sort_page(self):
        if not hasattr(self, 'ui_sort_page'):
            self.ui_sort_page = SortUI()  
        
        self.stackedWidget_2.addWidget(self.ui_sort_page) 
        self.stackedWidget_2.setCurrentWidget(self.ui_sort_page)

    def open_multi_sort_page(self):
        if not hasattr(self, 'multi_ui_sort_page'):
            self.multi_ui_sort_page = MultiSortUI()  
        
        self.stackedWidget_2.addWidget(self.multi_ui_sort_page) 
        self.stackedWidget_2.setCurrentWidget(self.multi_ui_sort_page)

import resources_rc


if __name__ == "__main__":
    import sys
    app = QtWidgets.QApplication(sys.argv)
    MainWindow = QtWidgets.QMainWindow()
    ui = Ui_MainWindow()
    ui.setupUi(MainWindow)
    MainWindow.show()
    sys.exit(app.exec_())
