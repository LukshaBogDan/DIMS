# HIMS.EF 
## Human resource management system  :books:

### 1) How to resolve issue with PK in views generated by EF?
	Read following links to figure it out and apply to your part of solution:
- https://stackoverflow.com/questions/24792259/error-6002-the-table-view-does-not-have-a-primary-key-defined
- https://www.dustinhorne.com/post/2016/12/10/views-and-incorrect-data-in-entity-framework

### 2) Good tutorial in ENGLISH to read about EF
- http://www.entityframeworktutorial.net

### 3) If you add new entity, procedure, view and etc., you need:
		3.1) run script to add it to database on your local server
		3.2) save script in HIMS.Database solution in an appropriate folder 
		3.3) update your HIMS.edmx model from your database 
		3.4) commit your changes

### 4) Git workflow:
Hot to name a branch: <br/>
your-name/feature <br/>
How to name a commit: <br/>
> Bad: "I added some features to my controller"
> Good: "Add GetUser action to UsersController"

```
git checkout <name of your branch>
git pull --rebase origin <name of origin branch>
(stash you shanges if you will be asked to do before pull and resolve conflicts if need and don't forget to apply your stash again)
	
git checkout -b <your-branch-name>
git status
git add . / git add "<name-of-file>"
git commit -m "<your-commit>"
git push -u origin <name of your branch>  // -u or --set-upstream
	
git checkout dev
git pull --rebase origin <name of origin branch> 
(stash you shanges if you will be asked to do before pull and resolve conflicts 
if need and don't forget to apply your stash again)
	
git merge <name of your branch> dev
git branch -d <name of your branch> //delete your branch after successful work completion
	
git push
```
- https://rogerdudler.github.io/git-guide/ - refresh you git knowledges step by step

### 5) How to enable sa user in MSSql
https://www.youtube.com/watch?v=Ckb-YoHsuOE

### 6) How to map stored procedure in EF
https://stackoverflow.com/questions/43821023/stored-procedure-in-entity-framework-database-first-approach
