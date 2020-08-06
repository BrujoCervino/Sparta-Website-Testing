# Sparta-Website-Testing

### A framework for testing Sparta Global's Assessment-tracking and -dispatching website 

## The Project

~ ***[Please refer to the Jira Project here](https://spartaglobal.atlassian.net/secure/RapidBoard.jspa?rapidView=243&projectKey=NG58FNLPRJ&view=planning&issueLimit=100)*** ~
<br/>
**Timeframe**: Mon: Jul-27-2020 - Fri: Aug-7-2020 (2 weeks)
<br/><br/>

### 1 - Goals and Definition of Done<br/><br/>

### 2 - Sprint Breakdown and Reviews<br/><br/>

### 3 - Sprint And Project Retrospectives<br/><br/>

## Code

### Getting Started

***1 ~*** Ensure you have a ```Config.json``` located within the ```/PageObjectModels``` folder
<img src="DocsImg/PageObjConfig.png" alt="PageObjConfig" width="512"/> <br/>

If you skip this step, this compile-time error will appear at least once:

<img src="DocsImg/MissingConfigError.png" alt="Missing Config Error" width="512"/> <br/>

***2 ~*** Add the fields you need into ```Config.json```

### Testing/adding a new page

***1 ~*** Add a new class (this will be your page object model) to the ```PageObjModels``` project which extends ```SuperPage```.

<img src="DocsImg/NewPomClass.png" alt="Adding a new page object model" width="512"/>

***2 ~*** Add a new .NET Framework class library project (.csproj) to the solution.

<img src="DocsImg/AddNewProj.png" alt="Adding a new project" width="512"/>

***3 ~*** Add dependencies to your project: right-click the solution file in the Solution Explorer

<img src="DocsImg/null.png" alt="Adding a new project" width="512"/>

### Projects

### Class Diagrams

|Name|Picture|
|-|-|
|||

### Agreed conventions (made only when needed)  

♦ ```public```, ```private``` and ```protected``` fields: <br/>

|Access modifier|Naming Convention|Case|Underscore?⬜️✅|
|---------------|-----------------|----|---------------|
|**public**|```public int MyInt;```|```PascalCase```|⬜️|
|**protected**|```protected int myInt;```|```camelCase```|⬜️|
|**private**|```private int _myInt;```|```camelCase```|✅|

♦ For ```public``` variables or properties whose name is a class name, use ```camelCase```: <br>
```public SpartaWebsite spartaWebsite;```<br>
```public SpartaWebsite spartaWebsite {get; set;}```<br>

♦ For (more readable) acronyms, don't use all caps: <br>
```API;``` ->```Api;```<br> 
```URLManager;```->```UrlManager;```<br>

♦ Git branch names - use only lowercase and dashes (avoids the possibility of duplicate branches):
```KieDocs```->```kie-docs``` 