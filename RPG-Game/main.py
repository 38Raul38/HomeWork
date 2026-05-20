import random

class Character:
    def __init__(self, name, health, attack_power):
        self.name = name
        self.health = health
        self.attack_power = attack_power

    def attack(self, other):
        damage = self.attack_power
        other.health -= damage
        print(f"{self.name} attacks {other.name} for {damage} damage!")

    def character_info(self):
        print(f"Name: {self.name}, Health: {self.health}, Attack Power: {self.attack_power}")

    def __str__(self):
        return f"{self.name} (Health: {self.health}, Attack Power: {self.attack_power})"

    def __add__(self, other):
        if isinstance(other, Character):
            return Character(
                f"{self.name} & {other.name}",
                self.health + other.health,
                self.attack_power + other.attack_power
            )
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


class Warrior(Character):
    def attack(self, other):
        damage = 20
        self.health += 10
        other.health -= damage
        print(f"{self.name} dismembers {other.name} for {damage} damage!")


class Mage(Character):
    def attack(self, other):
        damage = 40
        other.health -= damage
        if other.health <= 0:
            self.attack_power += 3
        print(f"{self.name} casts Finger of Death on {other.name} for {damage} damage!")


class Archer(Character):
    def attack(self, other):
        damage = 50 if random.random() < 0.35 else 30
        other.health -= damage
        print(f"{self.name} shoots {other.name} for {damage} damage!")


characters = [
    Mage("Leon", 100, 15),
    Warrior("WK", 120, 10),
    Archer("Robin", 90, 12)
]

print("--- Battle Start ---")

for i in range(len(characters)):
    attacker = characters[i]
    target = characters[(i + 1) % len(characters)]
    attacker.attack(target)

print("--- Battle End ---")

for c in characters:
    c.character_info()