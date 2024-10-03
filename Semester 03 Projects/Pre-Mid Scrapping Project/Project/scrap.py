from selenium import webdriver
from selenium.webdriver.common.by import By
from selenium.webdriver.support.ui import WebDriverWait
from selenium.webdriver.support import expected_conditions as EC
from bs4 import BeautifulSoup
import pandas as pd
import time

# Set up Selenium WebDriver (Chrome example)
def init_driver():
    return webdriver.Chrome()  # Ensure ChromeDriver is installed and in PATH

BASE_URL = 'https://www.zameen.com/Homes/Lahore-1-{}.html'
all_homes = []
scraped_pages = 0 
max_scraped_before_restart = 10  # Set a threshold for restarting the browser
driver = init_driver()  # Initialize the browser once at the start

try:
    for page in range(1, 1000): 
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

        for home in homes:
            try:
                title = home.find('h2', class_='_36dfb99f').text.strip() if home.find('h2', class_='_36dfb99f') else '2'
                price = home.find('span', class_='dc381b54').text.strip() if home.find('span', class_='dc381b54') else '2'
                full_location = soup.find('div', class_='db1aca2f').text.strip() if soup.find('div', class_='db1aca2f') else '2'

                if ',' in full_location:
                    location, city = map(str.strip, full_location.split(',', 1))
                else:
                    location = full_location 
                    city = '2'
                    
                beds = home.find('span', {'aria-label': 'Beds'}).text.strip() if home.find('span',  {'aria-label': 'Beds'}) else '2'
                baths = home.find('span', {'aria-label': 'Baths'}).text.strip() if home.find('span', {'aria-label': 'Baths'}) else '2'
                area = home.find('span',  {'aria-label': 'Area'}).text.strip() if home.find('span',  {'aria-label': 'Area'}) else '2'

                # Append extracted data to list
                all_homes.append({
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

        print(f"Scraped page {page}")
        scraped_pages += 1 

        # Restart the browser after scraping a set number of pages
        if scraped_pages >= max_scraped_before_restart:
            print("Restarting browser after scraping 10 pages.")
            driver.quit()  # Quit the current browser session
            time.sleep(5)  # Optional: Add a delay before restarting
            driver = init_driver()  # Re-initialize the browser
            scraped_pages = 0  # Reset the counter

        time.sleep(2)

finally:
    driver.quit()

# Save results
if all_homes:
    df = pd.DataFrame(all_homes)
    df.to_csv('zameen_homes1.csv', index=False)
    print("Scraping completed and saved to zameen_homes.csv")
else:
    print("No data scraped. Please check selectors and page content.")
