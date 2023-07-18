- Quick setup:
    - Run command "npx playwright install" to install browser engines on local machine.
    - Ensure that solution has access to "C:\Users\{username}\AppData\Local\ms-playwright" and is able to run chromium engine.
	
- Was made:
	- New playwright project created
	- Test case covered by SpecFlow
	- All automation framework is ready to deploy to any CI/CD pipeline (All environments are set at application config json file)
	- At the end of the test case playwright makes printscreens, you need to change directory were to save jpg
	- Two test cases for login page

- Was not made:
	- Strange behavior of chromium was observed. With correct logins an error appears "Captcha check failed. Try submitting your form again."