import random   
                                                 ############____ Character ____############
class Character:
    def __init__(self, name, health, attack_power):
        self.name = name
        self.health = health
        self.attack_power = attack_power

    def attack(self, other):
        damage = self.attack_power
        other.health -= damage
        print(f"{self.name} attacks {other.name} for {damage} damage!")

    def damage(self, amount):
        self.health -= amount
        print(f"{self.name} takes {amount} damage! Remaining health: {self.health}")

    def character_info(self):
        print(f"Name: {self.name}, Health: {self.health}, Attack Power: {self.attack_power}")

    def __str__(self):
        return f"{self.name} (Health: {self.health}, Attack Power: {self.attack_power})"

    def __add__(self, other):
        if isinstance(other, Character):
            combined_name = f"{self.name} & {other.name}"
            combined_health = self.health + other.health
            combined_attack_power = self.attack_power + other.attack_power
            return Character(combined_name, combined_health, combined_attack_power)
        return NotImplemented    

    def __lt__(self, other):
        if isinstance(other, Character):
            return self.health < other.health
        return NotImplemented   

    def __eq__(self, other):
        if isinstance(other, Character):
            return self.health == other.health and self.attack_power == other.attack_power
        return NotImplemented
    
    def __len__(self):
        return int(self.attack_power)

    def __bool__(self):
        return self.health > 0

                                                ############____ Warrior ____############
class Warrior(Character):
    def __init__(self, name, health, attack_power):
        super().__init__(name, health, attack_power)

    def Dismember(self, other):
        damage = 20
        self.health += 10
        other.health -= damage
        print(f"{self.name} performs a special attack on {other.name} for {damage} damage!") 

                                                ############____ Mage ____############
class Mage(Character):
    def __init__(self, name, health, attack_power):
        super().__init__(name, health, attack_power)

    def Finger_of_Death(self, other):
        damage = 40
        other.health -= damage
        if other.health <= 0:
            self.attack_power += 3
        print(f"{self.name} casts a fireball on {other.name} for {damage} damage!")

                                                ############____ Archer ____############
class Archer(Character):
    def __init__(self, name, health, attack_power):
        super().__init__(name, health, attack_power)

    def Marksmanship(self, other):
        if random.random() < 0.35:
            damage = 50
        else:
            damage = 30
        
        other.health -= damage
        print(f"{self.name} shoots an arrow at {other.name} for {damage} damage!")







leon =Mage("Leon", 100, 15)
wk = Warrior("WK", 120, 10)

leon.character_info()
wk.character_info()
print("--- Battle Start ---")
leon.attack(wk)
wk.Dismember(leon)
print("--- Battle End ---")
leon.character_info()
wk.character_info()
