# COVID-19 UPDATES API

COVID-19 UPDATES API is used to help customers obtain the status of COVID-19 casess. This application is used to view COVID-19 updates based on country through provience level. It also displays the total number of deaths,  infected, recovered and number of active casess based on the refined search though selected country and provience.

### Steps to clone the API source code FROM GIT Gub
1. Open command prompt and navigate to the desired path.
2. Clone the source code from the github repo and copy the path below and hit Enter
git clone https://github.com/ravikoppula/COVID19-UpdatesWebAPI.Net6.git
3. Open the folder path and find COVID19-UpdatesWebAPI.Net6.sln file. Also,
double clicking on the file will open the solution in the visual studio 2022.

### Steps Explore project folder structure
1. Inside the COVID19-UpdatesWebAPI.Net6 Solution, launchSettings.json can be found under the properties folder which helps to set up the launch settings.
2. Controllers can be found under the controller folder (which is used for request & user response)
2. Interfaces folder contains all the interfaces which are implemented for the future.
3. Services folder will store the logic and process HTTP response (User response).
3. Under the Models folder - View model and Data folder are stored.
4. View Models is used to bind the output parameter.
5. Data Folder will be used to store the files (Ref: Git repo).
7. View folder to design HTML pages to interact with the user.
8. Appsettings.json is used for data connection or any security tokens in the future for Git Access.
9. In Program.cs file contains all the dependency injection (DI) which is used in the project along with the routing path for project launch.

### Steps to build and run the API solution locally.
1. Build the solution by hitting F6 button. Alternatively, build option can be chosen from the top menu from Visual studio.
2. Run the solution by hiting F6 button. Consequently, hitting on Ctrl+shift+c keys will allow step 1 and step 2 to build and run the solution concurrently.
3. Once the build and run is sucessful, solution will render the default setting page followed by the display of the dashboard (use GOOGLE CHROME for better optimization)
4. API is tested from the frontend by entering the country,state and date inputs.

### Steps to run the test cases locally.
1. Right click on the COVID19-UpdatesWebAPI.Net6.XUnitTest solution and set as a start up project
2. Hit on Ctrl + R, A.
3. In the test explorer you will find the test cases status.

## Steps to test API via third party tools
#### Get all updates

```http
https://localhost:7139/api/covid19updates/getcovid19updates
```
#### Get updates based on input Parameters

```http
https://localhost:7139/api/covid19updates/getcovid19updates?country=Canada&state=&lastUpdatedDate=0001-01-01
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `country`      | `string` | **Optinal**. country name to get to fetch |
| `state`      | `string` | **Optinal**. state name to get to fetch |
| `lastUpdatedDate` | `datetime` | **Optinal**. datetime name to get to fetch |

#### getcovid19updates(country, state, lastUpdatedDate)
Takes country, state and last updated date and return the covid updates.

```bash
Note: Country, state and Last updated date are optional fields.**
```

## Steps to test API via third party tools
1. Login to Postman Web. Please click the link below to open Postman Web. Alternatively, Postman can be downloaded directly on Windows.
Post man web - https://interstellar-flare-1652.postman.co/
2. For first-time users, please sign-in to record your activities under history session.
3. Retain the solution in run mode to receive the API call.


### Test Case 1: View data based on country and state
``` 
https://localhost:7139/api/covid19updates/getcovi19dupdates?country=Brazil&amp;state=Ceara

API Response:
[
    {
        &quot;province\_State&quot;: &quot;Ceara&quot;,
        &quot;country\_Region&quot;: &quot;Brazil&quot;,
        &quot;confirmed&quot;: &quot;336504&quot;,
        &quot;deaths&quot;: &quot;10004&quot;,
        &quot;recovered&quot;: &quot;269846&quot;,
        &quot;active&quot;: &quot;56153&quot;,
        &quot;lastUpdatedDate&quot;: &quot;2021-01-02T05:22:33&quot;
    },

    {
        &quot;province\_State&quot;: &quot;Ceara&quot;,
        &quot;country\_Region&quot;: &quot;Brazil&quot;,
        &quot;confirmed&quot;: &quot;336574&quot;,
        &quot;deaths&quot;: &quot;10015&quot;,
        &quot;recovered&quot;: &quot;270203&quot;,
        &quot;active&quot;: &quot;56356&quot;,
        &quot;lastUpdatedDate&quot;: &quot;2021-01-03T05:22:52&quot;
    }
]
```
### Test Case 2: View data based on selected countries
API Request
```
https://localhost:7139/api/covid19updates/getcovi19dupdates?country=Brazil

API Response:

Resoinse JSON was not attached as the API response is lengthy.
```

### Test case 3: View data based on selected states
```
https://localhost:7139/api/covid19updates/getcovi19dupdates?state=Ceara
API Response:
[

    {
        &quot;province\_State&quot;: &quot;Ceara&quot;,
        &quot;country\_Region&quot;: &quot;Brazil&quot;,
        &quot;confirmed&quot;: &quot;336504&quot;,
        &quot;deaths&quot;: &quot;10004&quot;,
        &quot;recovered&quot;: &quot;269846&quot;,
        &quot;active&quot;: &quot;56153&quot;,
        &quot;lastUpdatedDate&quot;: &quot;2021-01-02T05:22:33&quot;
    },
    {
        &quot;province\_State&quot;: &quot;Ceara&quot;,
        &quot;country\_Region&quot;: &quot;Brazil&quot;,
        &quot;confirmed&quot;: &quot;336574&quot;,
        &quot;deaths&quot;: &quot;10015&quot;,
        &quot;recovered&quot;: &quot;270203&quot;,
        &quot;active&quot;: &quot;56356&quot;,
        &quot;lastUpdatedDate&quot;, 
	    &quot;2021-01-03T05:22:52&quot;
    }

]
```
### Test case 4: View data based on selected dates
```
API Request
https://localhost:7139/api/covid19updates/getcovi19dupdates?lastUpdatedDate=2021-01-02
```

```
Test 4: View data without any filter selection:
API Request
API Request: https://localhost:7139/api/covid19updates/getcovi19dupdates
```

### Running Tests
To run tests, run the following commands

```bash
  dotnet test
```
Run the tests using COVID19-UpdatesWebAPI.Net6.dll assembly:
```bash
dotnet test ~/COVID19-UpdatesWebAPI.Net6/COVID19-UpdatesWebAPI.Net6.XUnitTest/bin/debug/net6.0/COVID19-UpdatesWebAPI.Net6.dll
```

## Publish

Self-contained deployment windows

```bash
dotnet publish -c Release -r <RID> --self-contained false
dotnet publish -c Release
  
  ```

  ( or )
Publish an app self-contained and ReadyToRun. A Windows 64-bit executable is created.


```bash
dotnet publish -c Release -r win-x64 -p:PublishReadyToRun=true

```
Publish an app self-contained and ReadyToRun. A macOS 64-bit executable is created.
```bash
dotnet publish -c Release -r osx-x64 -p:PublishReadyToRun=true
  
```

### Tech Stack

**Client:** Bootstrap, HTML, CSS, Jquery and AJax

**.Net Version:** NetCore 6.0.301

**Solution pattern:** Model View Controller (MVC)

**Web Api** C#.

**Third Part Tools** Swagger UI to test API methods.

### Authors
- [@ravikoppula](https://github.com/ravikoppula/COVID19-UpdatesWebAPI.Net6.git)


