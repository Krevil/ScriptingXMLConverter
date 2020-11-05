# ScriptingXMLConverter
Converts Assembly scripting XML files to use decimals for opcodes

For example:

```
<function opcode="0x063" name="objects_attach" returnType="void" argc="4">
```

Will then be

```
<function opcode="99" name="objects_attach" returnType="void" argc="4">
```

This is useful because whilst the scripting XMLs use hexadecimal, Assembly will only take decimal numbers when entering in opcodes to the Script Expressions block.
