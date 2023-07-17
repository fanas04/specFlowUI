- Quick setup:
    - Run command "npx playwright install" to install browser engines on local machine.
    - Ensure that solution has access to "C:\Users\{username}\AppData\Local\ms-playwright" and is able to run chromium engine.
	
- Was made:
	- Created new playwright project
	- Test case coverd by SpecFlow
	- All automation framework is ready to deploy to any CI/CD pipline (All enviroment are set at application config json file)
	- In the end of test case playwright made printscreen, you need to change directory were to save jpg
	- Two test case for login page

- Was not made:
	- Strange behavior of chroium was observed. With correct logins I get an error "Captcha check failed. Try submitting your form again."