# dworkin
Dworkin is a discord bot which can be called to randomly generate various useful things for Dungeon and Dragons.

To do:

Tables
- New NPC names
- Clean up large _chaos_ wild magic table
- Add wondrous item tables
- Add wild surge duration table
- More wild surge tables

Behaviour/Architecture
- Better command structure
- Move tables to db (maybe dynamo) then setup tables on bot start
- Host bot on AWS
- Parse responses to automatically roll dice calls in strings. IE "You gain 1d3 wishes" would roll 1d3 and return the generated value in the string.
