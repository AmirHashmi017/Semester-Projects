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