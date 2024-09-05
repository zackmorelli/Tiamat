# Tiamat

This program is for use with ARIA/Eclipse, which is a commerical radiation treatment planning software suite made by Varian Medical Systems which is used in Radiation Oncology. This is one of several programs which I have made while working in the Radiation Oncology department at Lahey Hospital and Medical Center in Burlington, MA. I have licensed it under GPL V3 so it is open-source and publicly available.

There is also a .docx README file in the repo that describes what the program does and how it is organized.

Tiamat is an automatic plan creation script that I had a large vision for when I set out to make it after the department upgraded to Aria version 16 and thus made write-enabled scripting available to us. It is named after the Babylonian goddess of creation.

It was supposed to be a large program that would use write-enabled scripting to automate parts of the planning process, mostly by setting up beam geometry based on anatomical selections by the user. 

However, it was decided (and I agreed) that it was easier to automate treatment planning, and beam setup particularly, through the use of Eclipse plan templates. It was simply a matter of the department making a set of standardized plan templates and using them, which was not new in version 16, but had not been done yet at the point when we were going through this process.

So, I modified Tiamat so that it is only used to add imaging setup beams to a plan, which is useful, but all the code for doing all the other things that I had originally planned on is still there. If you are interested in ESAPI’s tools for programmatic beam creation and optimization objectives, I’m sure the code and set of classes I built out will be useful to you.

I also planned on Tiamat making use of my other ESAPI scripts PlanCheck and CollisionCheck.
The idea was that these plan evaluation scripts would run automatically after Tiamat had made a new plan.
That is why you will find files for those other scripts in this repo, however keep in mind those programs have their own repos.