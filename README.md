# Overview

This simple program shows basic example implementations of the singleton, observer and strategy patterns in C#.

# Motivation

Being fond of video games, especially Japanese video games, one is bound to stumble upon a certain indie game that claims to simulate a particular character trait in manga and anime, although the game isn't actually from Japan.
Somewhen around this year's beginning I read that the developer of the game has quite a distinct coding practice. This did arouse my interest, so I watched a video commenting on the coding style.
I agreed that I would have chosen a different approach to this specific task, so I tried to figure out a basic solution using my beginner's knowledge and basically any design pattern I could fit in.

# Problem

There is a set of students identified by a unique ID each who execute different activities depending on the time of day.

# My solution

There is a clock which can be observed by anybody who is interested in the current time of day. I implemented the clock as a singleton, as it's a game with a global time that is displayed by a single all-knowing clock, unless there's time travel involved.
I've chosen to simplify the problem and only display full hours. So the clock implements `IObservable<int>`.

There are two classes that can subscribe to the clock, the students who choose their activities according to the time and some weirdo who tells the time every full hour.
The observer pattern was implemented according to the official documentation.

As the activity of a student changes depending on the current hour during runtime, it seemed appropriate to give each student a dictionary that maps every hour to another strategy that's activity can be started, paused or resumed.
