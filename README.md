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

##Sample Implementation
There are few DTOs and a few test cases that would help explain the usage. 
###DTOs
Person, PersonWithAddress, PersonWithCitizenship
The objects change and after a while, new attributes are added to the object. 
A person, gets address and later on gets citizenship details. 

###Storage & Retrivals
Idea is to retrieve and object as a dynamic and then convert it to a version that you care about. 

###Test Case of importantance 
Do have a look at ConvertFrom_UnknowSerializedData_ToKnown_Test
