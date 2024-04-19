

WHAT ARE YOU DOING HERE?! #portrait:Kratos #speaker:Kratos
WHAT ARE YOU DOING HERE?!
WHO ARE YOU!!!! 
I was walking around my land. #portrait:MainPlayer #speaker:Me
	+[Ask him]
		-> askHim
	+[Run]
		-> run

=== askHim ===
So, what about you? #portrait:MainPlayer #speaker:Me
What are you doing here?
I'm trying to reach Zeus to get my revenge! #portrait:Kratos #speaker:Kratos
Do you know where he is hiding?
	+[Yes]
		-> yesZeus
	+[No]
		-> noZeus

=== yesZeus ===
Yeah... I think he's at Mount Olympos. #portrait:MainPlayer #speaker:Me
Get out of my way! #portrait:Kratos #speaker:Kratos
-> END

=== noZeus ===
No. #portrait:MainPlayer #speaker:Me
Get! Out of! My way! #portrait:Kratos #speaker:Kratos
-> END

=== run ===
Uh, oh... Bye! #portrait:MainPlayer #speaker:Me
-> END
