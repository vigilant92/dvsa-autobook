# This is for educational purpose only
# Dvsa-autobook
A small executable to check DVSA practical driving test and book automaticly if it finds one with suitable month. It will only work if you already have a booking, as this is 
generally the case when you look for a cancellation (you book a test in the future, and check regularly to see if you can get it moved forward). 

Last confirmed working: 1 March 2022

# Usage
Fill up all the fields, on the text box's
on Search For (Write the post code of location you are searching for, for example "sm6")
on Month/Year (Write the month and year in digit, for example "07/2022")
on Avoid for (Write any location if you want to avoid, for example "Croydon")

then click Start, It will login automatically, then search for location's near sm6 on every 15 sec. (you can change the box from 15000 to anything to change the time)

if it gets any time
#
![111121](https://user-images.githubusercontent.com/48102142/157457408-d29fbcf3-2d7d-4026-ba31-79198881644b.JPG)

# Limitations
If you repeatedly run the program, the DSA website will start serving you up captchas. They are solvable by computers, but this requires use of a paid service (for example 2Captcha, companies that sell software to check for DSA cancellations utilize these).
Another limitation is you can only select a month, and it will book the first date that is available of that month.

I have also written the same thing using javascript and with using Ui Vision RPA, using that you can eliminate the captcha (it will solve the captcha as they are simple one)
