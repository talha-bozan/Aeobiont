INCLUDE ../../global.ink

{ choice_name_sasori == "": -> main | -> already_chose }

=== main ===
Do you want to meet this woman? #portrait:YoungWoman #speaker:Game
    + [Yes]
        -> chosen("Yes")    
=== chosen(Yes) ===
~ choice_name_sasori = "chosed"
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
~ choice_name_sasori = option
Hi! You're the new villager, right? #portrait:YoungWoman #speaker:Game
-> END
//FRIENDLY ENDED


=== chosenMean(option) ===
~ choice_name_sasori = option
You bully! #portrait:YoungWoman #speaker:Game
-> END

=== chosenRomance ===
{ isRomanceS == "": -> flirt("chosedFlirt") | -> mainRomance }


=== flirt(option) ===
~ isRomanceS = option
Eyyy :3 #portrait:MainPlayer #speaker:Game
-> END

=== mainRomance ===
	+[Ask About Love]
		-> answerRomance("friendly10")
	+[Compliment Apparance]
		-> answerRomance("friendly10")
	+[Risque Question]
		-> answerRomance("Risque")

=== answerRomance(option) ===
:3 Meowwwww... #portrait:YoungWoman #speaker:Game
~ choice_name_sasori = option
-> END

/*
=== chosen2(option) ===
~ choice_name_sasori = option
bye! #portrait:YoungWoman #speaker:Game
-> END

*/