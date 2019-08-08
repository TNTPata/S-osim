# Documentation* for Säosim
*actually not a documentation, but a report, a short clip, and some other things that might prove useful to understanding the project. 

1. The report ("Projektrapport Gymnasiearbete.docx")(and this project) was written by me (TNTPata) as my High-school diploma project. The goal of the project was to simulate an interlocking plant at a small- to mid-size station in Sweden during the early 1900s. The explicit goals of the project are written down in the project report. However, the report is written in swedish, as I'm swedish. I may decide to put in the effort to translate it to english. Someday. Maybe.
2. The folder "Bilagor" (Attachments) contains files related to the report. 
	1. "Signalplanritning" is a schematic drawing of the station that the program is trying to simulate. 
	2. "Förreglingstabell" is a table that shows what position switches and whatnot must be in for a specific route to be set.
	3. "Kontroll av Växel" is a flowchart made to illustrate how the program checks variables and positions before throwing a switch. 
	4. "BVF 544.94005" are regulations published by the former Swedish Railway Administration (Banverket, now Trafikverket), regarding the use of special "control-keys" which were used more frequently in the early 1900s. 
	5. An extract from Swedish State Railways Handbook SJH 325.1, Signalteknisk Handbok, 1958. (Handbook about railway signaling technology, 1958).
	6. A document containing explainations to the symbols used in "Bilaga 1-Signalplanritning". 
	7. "Banlära Band 2" is a book published by the Swedish Royal Railway Council in 1916. It thuroughly describes how railways and railway signaling technology are built (in 1916). 
3. "Kodutveckling Gymnasiearbete.mp4" is a short movie made with the plugin Gource (https://gource.io/). It roughly works by reading log files and visualising them. A blob represents a file, and each color represents a file type. The strings between the clusters of blobs are folders. Every time I "shoot a blob with a laser", I make some type of change to a file. A green laser is the creation of a new file. Yellow lasers mean that I just changed something inside the file. A red laser means I removed the file. Pay attention to the date displayed. It might seem that the development was even and I worked continously on the project, however, I assure you I did not.
