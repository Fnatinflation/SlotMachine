from math import comb

r = 3244

r1 = 1*r
r2 = 2*r
r3 = 4*r
r4 = 6*r
r5 = 8*r
r6 = 13*r
r7 = 18*r
r8 = (1+1+2+2+2+5+5+5)*r
r9 = (1+1+2+2+2+5+5+5+10)*r
r9 = (1+1+2+2+2+5+5+5+10+10)*r
r10 = (1+1+2+2+2+5+5+5+10+10+10)*r
r11 = (1+1+2+2+2+5+5+5+10+10+10+10)*r
r12 = (1+1+2+2+2+5+5+5+10+10+10+10+10)*r
r13 = (1+1+2+2+2+5+5+5+10+10+10+10+10+10)*r
r14 = (1+1+2+2+2+5+5+5+10+10+10+10+10+10+10)*r
r15 = (1+1+2+2+2+5+5+5+10+10+10+10+10+10+10+10)*r

payoffs = []
payoffs.append(r1)
payoffs.append(r2)
payoffs.append(r3)
payoffs.append(r4)
payoffs.append(r5)
payoffs.append(r6)
payoffs.append(r7)
payoffs.append(r8)
payoffs.append(r9)
payoffs.append(r10)
payoffs.append(r11)
payoffs.append(r12)
# payoffs.append(r13)
# payoffs.append(r14)
# payoffs.append(r15)


#Chance of win
p = 0.34


# Chance of bonus game
b = 0.000488281

payout = 0
print(comb(15,2))
for w in range(0,len(payoffs)):
    value = comb(15,w) * (p**w)*((1-p)**(15-w))*payoffs[w]
    payout+=value
print(payout)

machineValue = b*payout + (1-b)*r
print(machineValue/4096)