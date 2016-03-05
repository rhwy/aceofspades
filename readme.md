#Ace of Spades

What about having a tool that gives you some real time feedback in a very simple way, that
integrates smoothly with your tools, habits and available from the command line?

It's about Experience driven design, providing inputs and see live outputs of the function
you are actually working on, one at a time. 

## Todo for going from POC to PROD

* split runner and core. 
* be able to load project from any working folder (actually just works with this poc assembly)

## Ideas & Next Steps

* call an experiment as argument if you want to test something specific whereas it is not in state `Play.Now`
* after some play while working on it, it should be also a great tool for koans like interactive tutorial. 
plan your learning sequences within experiments and specify to set state to Play.Later and go to next step, etc...
* interactive documentation can be generated with these experiments. If you specify a file in app argument, 
you can imagine to print to this file the output of the experiments marked as `Play.Documentation`.
* you can run very simple pre-scripted demos with different values (test it with a nancy rest service creation and a Nancy.Testing.Browser with differents values in an experiment)

