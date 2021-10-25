Assignment #1
Jongwon Shinn A00407059
-------------------------------------------------------------------

The goal of the assignment is to simply combine programs into a single
program that will recursively read a series of data files in CSV format and enter 
them into a single CSV file.

The user needs to enter and set the three pathes in the code for reading directory, output of CSV and logfile.

Some lines in the file will contain incomplete records which includes nothing and should be 
ignored (and logged) –Counted as skipped row.
The rows merged to a single CSV file will be counted as valid row.

The program logs the amount of total time it takes to read the files in each directory 
and the time it takes to write the files to a CSV file using the logWriter.
Also, the logWriter shows the each total number of valid rows and skipped rows as well as all exceptions.
