-> main
 ===main ===
 Hello Sir, Im sure I don't need to express our sadness of you leaving us, as im sure you are well aware we are sad to see you go, however it is business as usual for us.
 Some researchers have come to us with a concern over invasive species threathening the local fauna in our river and have asked us to help them resolve this issue.They want to try dump some chemicals into the river to drive away the invaders, they are unsure how this will go, should we help them?
 +[Help them]
 -> chosen("Help researchers")
 + [Dont help]
 -> chosen ("Don't help them")
 === chosen(choice)===
 Very well, we will go with your option of {choice}.
 -> END