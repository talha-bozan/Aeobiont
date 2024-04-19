INCLUDE ../../global.ink

{ choice_name_MWoman == "": -> main | -> already_chose }

=== main ===
Do you want to meet this woman? #portrait:MiddleAgeWoman #speaker:Game  
    + [Yes]
        -> chosen("Yes")    
=== chosen(Yes) ===
~ choice_name_MWoman = "chosed"
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
~ choice_name_MWoman = option
Hello, sweetie! #portrait:MiddleAgeWoman #speaker:Game  
-> END
//FRIENDLY ENDED


=== chosenMean(option) ===
~ choice_name_MWoman = option
You bully! #portrait:MiddleAgeWoman #speaker:Game  
-> END

=== chosenRomance ===
{ isRomanceMW == "": -> flirt("chosedFlirt") | -> mainRomance }


=== flirt(option) ===
~ isRomanceMW = option
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
Oh, you're so sweet! #portrait:MiddleAgeWoman #speaker:Game  
~ choice_name_MWoman = option
-> END

/*
=== chosen2(option) ===
~ choice_name_MWoman = option
bye! #portrait:MiddleAgeWoman #speaker:Game  
-> END

*/