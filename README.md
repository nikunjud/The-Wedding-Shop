# The-Wedding-Shop
Rover Problem - Nikunj Bhargava

Assumptions
1) Upper-right coordinates of the plateau will be more than 0,0 i.e. at least one of the coordinates either x or y is greater than 0.
2) At least one rover is assumed to be deployed and any result will be generated only if there are at least 2 lines of input.
3) Any number of Rovers can be deployed and their information is captured in the format described in the Requirement Document (Each rover has two lines of input. The first line gives the rover's position, and the second line is a series of instructions telling the rover how to explore the plateau.)
4) In case the rover's position is in an invalid format i.e. anything other than << xCoordinate >> << yCoordinate >> << Direction[N/S/E/W] >> then the Rover's resultant position will not be generated.
5) Direction inputs are case insensitive.
6) Instructions telling the rover how to explore the plateau can include invalid commands but those commands are ignored by the rover no movement would happen based on the same.
7) Rover's initial position must be entered within the plateau range i.e. 0 <= XCoordinate <= max XCoordinate and 0 <= YCoordinate <= max YCoordinate
8) Any of the commands that require the rover to move beyond the range of the plateau shall be ignored and thus the Rover will always stay within the plateau range described above.
