# Job interview: SOLID principles test
A programming job interview questions that test the understanding of basic principles and patterns

The test should be solved in two rounds, the text of the second round given to the job applicant only after they solve the first round. The purpose of these rounds is to check if the applicant can plan ahead and write extensible code before additional features are known.

---

Write an application (it can be a console / terminal application or an application with a GUI).
Use the programming language of your choice.
The code must be modular and easily extensible.
After you complete the first 5 tasks you will receive 3 very short additional tasks to test if the code is really easily extensible.

Round 1:

1. Design a ferry terminal. Two kinds of ferries are available at any time:
   - small ferry has space for 8 small vehicles (cars pay 3€ / vans pay 4€)
   - large ferry has space for 6 large vehicles (buses pay 5€ / trucks pay 6€)
   
   The application must display all income made from tickets.
2. Vehicles are constantly arriving to the terminal in random order.
   A terminal employee is paid to park them on the ferry - his salary is 10% of every ferry ticket.
   The application must display his income.
3. Every vehicle arrives with a random amount of gas.
   If any vehicle has less than 10% of gas left, the terminal employee must fill it up at the gas station.
   The application must display the amount of gas for the current vehicle.
4. Every van and every truck must go through customs inspection.
   The terminal employee must open the cargo doors for inspection.
   The application must display whether the cargo doors of the current vehicle are open or closed.
5. Track the car from the arrival to the ferry.
   The application must display the name of the last location visited (crossroads don't count).

            A
            |
        G - 1 - S
        |   |
        C - 2 - L
    
        A - Arrival
        G - Gas station
        1 - crossroad 1
        S - Small ferry
        C - Customs inspection
        2 - crossroad 2
        L - Large ferry

Round 2:

6. Add another terminal employee that does the exact same job.
   His salary is 11% of every ferry ticket.
   The application must display his income.
7. Add a battery recharge station.
   Every electric car arrives with a random battery charge.
   If the battery is below 10% then the terminal employee must recharge it.
   The application must display the battery charge for the current vehicle.
8. Add a new eco ferry that carries 10 eco cars (electric cars pay 1€ / hybrid cars pay 2€).
   Hybrid cars don't have to be refilled with gas if they have more than 50% battery charge.
   Hybrid cars don't have to have the battery recharged if they have more than 50% of gas left.

            A
            |
        G - 1 - S
        |   |
        C - 2 - L
        |   |
        B - 3 - E
	
        A - Arrival
        G - Gas station
        1 - crossroad 1
        S - Small ferry
        C - Customs inspection
        2 - crossroad 2
        L - Large ferry
        B - Battery recharge station
        3 - crossroad 3
        E - Eco ferry

In the first round you were asked to write modular and easily extensible code. It there anything you could have done differently in the first round that would make the last three tasks of the second round easier? If yes, what exactly?
