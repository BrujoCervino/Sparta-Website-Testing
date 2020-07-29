# Sparta-Website-Testing

### A framework for testing Sparta Global's Assessment-tracking and -dispatching website 

## The Project

~ ***[Please refer to the Jira Project here](https://spartaglobal.atlassian.net/secure/RapidBoard.jspa?rapidView=243&projectKey=NG58FNLPRJ&view=planning&issueLimit=100)***
<br/>
**Timeframe**: Mon: Jul-27-2020 - Fri: Aug-7-2020 (2 weeks)
<br/><br/>

### 1 - Goals and Definition of Done<br/><br/>

### 2 - Sprint Breakdown and Reviews<br/><br/>

### 3 - Sprint And Project Retrospectives<br/><br/>

## Code

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