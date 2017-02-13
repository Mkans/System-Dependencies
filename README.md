# System-Dependencies.io

The task here is to create an environment in which we can install / remove software
components while keeping track of their dependency software list.

For example: There are two scenarios,

1.INSTALL :
If you want to install a software, lets call it 'A' which depends on software 'B'
you need to install B for A to function properly.
2.REMOVE :
In the same way, you can't remove 'B' as there is software 'A' that's depend on it.

Please read the index.txt for the complete question.

How to solve it ?

1. First read all the dependencies, and store it in a list
2. Create an object for each software, with follwing attributes,
  a. Installation flag - to keep track whether it's installed or not
  b. Dependency list of objects - list of all the software it's depends on
  c. Depended by list of objects - listo of all the softwares depended by this software
The advantage of using objects here, is it will automatically update the list of depended lists for you. 
Please take a look at the class 'Program' to see how to do it. 
3. Once the dependency lists are created, now it's time for installation / removal.
4.Install a component.
  a. If it's already installed, throw the statment "Already installed"
  b. If it's not, then go ahead and install it. Now, go to the dependency list,
     check all the software it's depended by are installed. If not, install them to.
Tips: Use recursive function here, to do that.
5. Removing a component
  a. If it's already removed, go ahead and say "The software is not installed"
  b. If it's not, then go ahead check whether all the software depended by this program are removed,
     if all the software are removed, then uninstall the software.
Tips : Use recursive function to do this. I have used counter to keep track of whether all the software are
       uninstalled. 
6. List - list all the program that has all the software that has been installed (installation flag = 'true')
