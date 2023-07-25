-> main
 ===main ===
 Hello Sir, It seems helping those researchers proved to be beneficial for our companies name, but it also opened a new opportunity to us. Since we have already used the river for chemicals, we could start using the river to dump some of the excess waste we have, since we are running out of storage. Or we could spend money to upgrade the storage facility, which would you advise?
 +[Dump in river]
 -> chosen("Dump in the River")
 + [Upgrade Storage]
 -> chosen ("Upgrade storage")
 === chosen(choice2)===
 Very well, we will go with your option of {choice2}.
 -> END