# RegexForXmlNode
Regex pattern for XmlNode

## argument: 
node1.node2(name1=value1,name2=value2).node3=value          

Nodes = {node1 , node2(name1=value1,name2=value2) , node3}

For every node in Nodes there will be  AttributeNames and AttributeValues <br />
example for Node = node2(name1=value1,name2=value2) <br />
AttributeNames = {name1,name2}  <br />
AttributeValues = {value1,value2} <br />

Value = {value}

### Examples of some valid test cases
node1(b=c).node2=value  <br />
node(a=b,c=d).node=value  <br />
node1=value  <br />
node(b=c)  <br />

### Examples of some invalid test cases
.node.node(a=b)(a=d)  <br />
node(a=b,c=d)node  <br />
node(a=b)=value=value  <br />
node(a=b)==value  <br />
node(a=b)=value=  <br />
node(a=b)=  <br />

### Note
No spaces between testcase.<br />
can check here for complete argument match 
[Pattern Match Tester](http://regexstorm.net/tester?p=%28%3f%3cNodeList%3e%28%3f%3cNode%3e%5cw%2b%29%28%5c%28%28%3f%3cAttrName%3e%5cw%2b%29%3d%28%3f%3cAttrValue%3e%5cw%2b%29%28%2c%28%3f%3cAttrName%3e%5cw%2b%29%3d%28%3f%3cAttrValue%3e%5cw%2b%29%29*%5c%29%29%7b0%2c1%7d%29%28%5c.%28%3f%3cNodeList%3e%28%3f%3cNode%3e%5cw%2b%29%28%5c%28%28%3f%3cAttrName%3e%5cw%2b%29%3d%28%3f%3cAttrValue%3e%5cw%2b%29%28%2c%28%3f%3cAttrName%3e%5cw%2b%29%3d%28%3f%3cAttrValue%3e%5cw%2b%29%29*%5c%29%29%7b0%2c1%7d%29%29*%28%3d%28%3f%3cValue%3e%5cw%2b%29%29%7b0%2c1%7d&i=nodD12%28a%3db%29%3dvalue&l=100)
<br />The above tester matches complete argumnent
