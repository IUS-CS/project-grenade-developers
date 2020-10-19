## Design Patterns

### Description of the Patterns We Currently Implement

#### Abstract Factory 
Defines an interface for creating objects, but lets subclasses decide which class to instantiate and Refers to the newly created object through a common interface. 

The subclasses present within the game have a defined interface, a default prefab or script,  from which they gain their properties from and reference that script or prefab through common inference with newly created objects and preexisting objects. 

#### Adapter
Convert the interface of a class into another interface clients expect. / Adapter lets classes work together, that could not otherwise because of incompatible interfaces. 

Specific Enemy AI classes adapt to the Generic Interface.

#### Bridge 
Compose objects into tree structures to represent part-whole hierarchies. / Composite lets clients treat individual objects and compositions of objects uniformly.

Our tree-like hierarchy allows for scripts like MovingObject to be inherited uniformly by the objects that are given inference to that script. The hierarchy “bridges” the gap between the MovingObject Class and other classes like Enemy and Player.

#### Prototype 
Specify the kinds of objects to create using a prototypical instance, and create new objects by copying this prototype.

The moving object class is a prototype of how each object that moves should behave. However, different objects behave differently in which we have to account for my creating filler scripts to finish the prototype code the moving object class provides to the objects that inherit it.

#### Singleton
Ensure that only one instance of a class is created and Provide a global access point to the object.

In the loader script, we ensure that only one instance of the GameManager object is loaded. This is because the GameManager is the backbone of the program and we do not need multiple instances of this class as it would be a waste of resources and would cause issues.

### List of Patterns Which May or Can Be Implemented Into Our Design

#### Builder
Defines an instance for creating an object but letting subclasses decide which class to instantiate and Allows a finer control over the construction process.

#### Factory
Creates objects without exposing the instantiation logic to the client and Refers to the newly created object through a common interface.

#### Strategy
Define a family of algorithms, encapsulate each one, and make them interchangeable. Strategy lets the algorithm vary independently from clients that use it. 

### How We Plan/Intend To Design/Implement Modules In Our Code

#### Builder 
The different enemy types decide what type they are from the level generation classes higher up in the hierarchy. 
Example: Red Type enemies decide what it is based on the procedural level generation and a differentiation in its behavior given by the specific AI class.

#### Factory 
When the player instantiates a new instance of the game, the level is generated quickly behind the screens and keeps both the algorithms, and the interface secret from the player so that they can discover it while playing.

#### Strategy
The Enemy AI’s (with the exception of Red Type) handle situations by taking in information about their environment and changing their behaviors accordingly. Example: the orange AI actually consists of multiple modes, or strategies by which it roams around the map either hunting or hiding from the player, depending on if there are other enemies nearby.

