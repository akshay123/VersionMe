#VersionMe
=========
This is a tool to use to convert objects from one version to another and tightly controlling their interaction. 

##Primary Usage
Predominantly this would be used when a DTO is stored to the disk or in a NoSQL document database in a particular version, 
after a while the DTO would change and more attributes gets added to the DTO. 

Now in the world of c# statically typed objects when retrieved would start failing because of the type mismatch. 

###How Version Me works?
Each object would have to implement and Upgrade, Downgrade method that knows how to get to its adjacent version. 
Both forward and backwards. This is implemented using the interface IVersionConverter on the DTO.

###Version Numbers
Version numbers on DTO provide a quick way to jump from any version to any version. Without the version numbers you can still
achieve the desired behaviour; however it would up to the user to know which direction (upgrade, or downgrade) to go. 
Just mark the class with a version number. 


