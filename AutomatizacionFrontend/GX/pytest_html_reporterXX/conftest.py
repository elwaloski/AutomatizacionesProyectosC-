import pytest
import os
from selenium import webdriver
from pytest_html_reporter import attach
from pytest_html import extras
import sys
import os

sys.path.insert(0, os.path.abspath(os.path.dirname(__file__)))

# Hook para capturar screenshots en todas las pruebas
@pytest.hookimpl(tryfirst=True, hookwrapper=True)
def pytest_runtest_makereport(item, call):
    outcome = yield
    report = outcome.get_result()
    
    if report.when == "call":  # Captura en todas las pruebas, no solo en fallos
        if "setUpClass" in item.funcargs:
            web_driver = item.funcargs["setUpClass"]
            if web_driver is not None:
                try:
                    attach(data=web_driver.get_screenshot_as_png())
                    print("Captura de pantalla tomada y adjuntada al reporte con pytest-html-reporter.")
                except Exception as e:
                    print(f"Error al adjuntar usando pytest-html-reporter: {e}")
            else:
                print("Error: El objeto web_driver es None.")
        else:
            print("Error: La fixture 'setUpClass' no está disponible en el contexto de prueba.")
