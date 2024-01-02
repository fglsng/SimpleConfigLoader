# SimpleConfigLoader
### Purpose
To effeciently and in a ___very simple___ way load a file used to store configuration information for a piece of software.

### Current Limits
* Only local files.
* Only json.  

  
  
# Usage  
## Generic Configuration
The library can read using the predifined ***"SimpleConfigLoader.GenericConfiguration"*** class which is in inheriting from Dictionary<string,object> and has the method ***"GetValue\<T>"*** to retrieve values with a given key.
``` C#
var conf = new SimpleConfigLoader.GenericConfiguration();

conf.Add("FooStr", "Bar");
conf.Add("FooInt", 1234);

var strVal = conf.GetValue<string>("FooStr"); // is assigned "Bar" of type String
var intVal = conf.GetValue<int>("FooInt"); // is assigned 1234 of type Integer
```
Any loading where a Type is not provided returns an object of the type ***SimpleConfigLoader.GenericConfiguration***.

## Loading Configuration
### From Path

#### Generic
``` c#
var path = Environment.CurrentDirectory;

var config = SimpleConfigLoader.Load.FromPath(Path.Combine(path, "Config", "config.json"));
```
#### With Type
``` c#
var path = Environment.CurrentDirectory;

var config = SimpleConfigLoader.Load.FromPath<SomeClass>(Path.Combine(path, "Config", "config.json"));
```
### From Root

FromRoot is basically just an incapsulation of FromPath, doing the work of combining the path of *Environment.CurrentDirectory* and the filename. The configuration file must therefore be placed in the root folder of where your program is executed.

#### Generic
``` c#
var config = SimpleConfigLoader.Load.FromRoot("config.json");
```
#### With Type
``` c#
var config = SimpleConfigLoader.Load.FromRoot<SomeClass>("config.json");
```
## Example of Configuration File
``` json
{
  "FooStr" : "Bar",
  "FooInt": 1234,
  "FooList": [
    "a",
    "b",
    "c"
  ],
  "FooObj": {
    "Foo" : "Bar"
  }
}
```
Where the configuration can be loaded into ***GenericConfiguration*** without any issues, or defined into a class:
``` c#
private class SpecificConfig
{
    public string? FooStr { get; set; }
    public int? FooInt { get; set; }
    public List<string>? FooList { get; set; }
    public SpecificSubConfig? FooObj { get; set; }
}

private class SpecificSubConfig
{
    public string? Foo { get; set; }
}
```