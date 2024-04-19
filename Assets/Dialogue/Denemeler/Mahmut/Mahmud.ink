INCLUDE ../../global.ink

{ choice_name == "": -> main | -> already_chose }

=== main ===
Do you want to meet this guy? #portrait:YoungMan #speaker:Game 
    + [Yes]
        -> chosen("Yes")    
=== chosen(Yes) ===
~ choice_name = "chosed"
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
~ choice_name = option
Howdy! #portrait:YoungMan #speaker:Game 
-> END
//FRIENDLY ENDED


=== chosenMean(option) ===
~ choice_name = option
You bully! #portrait:YoungMan #speaker:Game 
-> END

=== chosenRomance ===
{ isRomance == "": -> flirt("chosedFlirt") | -> mainRomance }


=== flirt(option) ===
~ isRomance = option
Eyy :3
-> END

=== mainRomance ===
	+[Ask About Love]
		-> answerRomance("friendly10")
	+[Compliment Apparance]
		-> answerRomance("friendly10")
	+[Risque Question]
		-> answerRomance("Risque")

=== answerRomance(option) ===
Oh, you! #portrait:YoungMan #speaker:Game 
~ choice_name = option
-> END

/*
=== chosen2(option) ===
~ choice_name = option
bye!
-> END

*/