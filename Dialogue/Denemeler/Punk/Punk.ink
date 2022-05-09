INCLUDE ../../global.ink
{ choice_name_Punk == "": -> main | -> chosen }
=== main ===
Hey! Where do you think you're going? #portrait:Punk #speaker:Punk
	+[Run!]
	Bye! ->END
	+[Meet]
	Hi, who are you? #portrait:MainPlayer #speaker:Me
	I'm the guardian of the bridge! #portrait:Punk #speaker:Guardian
	~ choice_name_Punk = "chosed"
	-> END
=== chosen ===
Hi, may I ask you a question? #portrait:MainPlayer #speaker:Me
	+[Ask House]
		->askHouse
	+[Feel]
		->feel
	 
=== askHouse ===
~ choice_name_Punk = "social10"
How am I supposed to know? #portrait:Punk #speaker:Guardian
Go ask the mayor, maybe he knows.
Now, get away from here!
-> END

=== feel ===
~ choice_name_Punk = "social10"
It's none of your business! #portrait:Punk #speaker:Guardian
Get away from here!
-> END

	
	
