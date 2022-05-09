INCLUDE ../../global.ink

{ choice_name_MMan == "": -> main | -> already_chose }
	
=== main ===
Do you want to meet this guy? #portrait:MiddleAgeMan #speaker:Game
    + [Yes]
        -> chosen("Yes")    
=== chosen(Yes) ===
~ choice_name_MMan = "chosed"
You met! #portrait:MainPlayer #speaker:Game
-> END

=== already_chose ===
What do you want? #portrait:MainPlayer #speaker:Game
	+[Friendly]
		-> chosenFriendly
	+[Romance]
		-> chosenRomance
	+[Mean]
		-> chosenMean("20friendly")

//FRIENDLY STARTED
=== chosenFriendly ===
Choose one of them. #portrait:MainPlayer #speaker:Game
	+[Get To Know]
		-> incraseFriendly("friendly10")
	+[Ask About Day]
		-> incraseFriendly("friendly10")
	+[Discuss Interests]
		-> incraseFriendly("friendly10")

=== incraseFriendly(option) ===
~ choice_name_MMan = option
Hello there, young blood. #portrait:MiddleAgeMan #speaker:Game
-> END
//FRIENDLY ENDED


=== chosenMean(option) ===
~ choice_name_MMan = option
You bully! #portrait:MiddleAgeMan #speaker:Game
-> END

=== chosenRomance ===
{ isRomanceMM == "": -> flirt("chosedFlirt") | -> mainRomance }


=== flirt(option) ===
~ isRomanceMM = option
Eyy :3 #portrait:MainPlayer #speaker:Game
-> END

=== mainRomance ===
	+[Ask About Love]
		-> answerRomance("friendly10")
	+[Compliment Apparance]
		-> answerRomance("friendly10")
	+[Risque Question]
		-> answerRomance("Risque")

=== answerRomance(option) ===
~ choice_name_MMan = option
Well, I might try new things... #portrait:MiddleAgeMan #speaker:Game
-> END

/*
=== chosen2(option) ===
~ choice_name_MMan = option
bye! #portrait:MiddleAgeMan #speaker:Game
-> END

*/