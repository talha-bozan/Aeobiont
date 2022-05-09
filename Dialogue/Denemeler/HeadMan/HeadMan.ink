INCLUDE ../../global.ink
{ choice_name_HMan == "": -> main | -> chosen }

=== main ===
I think he's the mayor I'm looking for. #portrait:MainPlayer #speaker:Me
Do I really want to meet this guy? 
    + [Yes]
	Hi sir!
        -> chosen
	+ [No]
	Bye, you little rascal! #portrait:HeadMan #speaker:Mayor
		-> END
		
=== chosen ===
~ choice_name_HMan = "chosed"
Hi, what do you want? #portrait:HeadMan #speaker:Mayor
	+[Meet]
		-> meet
	+[Ask The Election]
		-> election
	+[Ask My Land]
		-> land
== meet ==
~ choice_name_HMan = "social10"
Who are you? #portrait:MainPlayer #speaker:Me
I'm the mayor. #portrait:HeadMan #speaker:Mayor
-> END

== election ==
~ choice_name_HMan = "social10"
What's the election about? #portrait:MainPlayer #speaker:Me
My time is short and this town needs a new mayor, So the village decided to elect... #portrait:HeadMan #speaker:Mayor
A new mayor. I hope they lose! 
-> END

== land ==
~ choice_name_HMan = "social10"
Where is my land? #portrait:MainPlayer #speaker:Me
Go right until you see the farm. #portrait:HeadMan #speaker:Mayor
Your land is below it.
-> END

