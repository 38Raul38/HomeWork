<<<<<<< HEAD
=======

>>>>>>> e3ab5446875e652e9e623bb3a97c1af90c77d429
def fibonacci_generator():
    a, b = 0, 1
    while True:
        yield a
        a, b = b, a + b

gen = fibonacci_generator()
<<<<<<< HEAD

=======
>>>>>>> e3ab5446875e652e9e623bb3a97c1af90c77d429
for _ in range(10):
    print(next(gen))