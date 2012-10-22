

@echo off
cls

sqlcmd -E -S .\sqlexpress -i ./DropDb.sql   