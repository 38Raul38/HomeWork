//Task1

// function compareNumbers(num1, num2){
//     if(num1 > num2){
//         console.log(1)
//     } else if(num1 < num2){
//         console.log(-1)
//     } else{
//         console.log(0)
//     }
// }


//Task2

// function Factorial(number){
//      let p = 1
//     for(let i = 1; i <= number; i++){
//             p = p * i
//     }
//     return p;
// }

// console.log(Factorial(5))

//Task 3

// function combineDigits(num1, num2, num3){
//     return Number(`${num1}${num2}${num3}`)
// }

// console.log(combineDigits(1, 2, 3))

//Task 4

// function Area(lenght, width){
//     if(width == undefined){
//         return lenght * lenght
//     } else{
//         return lenght * width
//     }
// }

// console.log(Area(5))

//Task 5

// function IsPerfectNumber(number){
//     let sum = 0;
//     for(let i = 0; i < number; i++){
//         if(number % i === 0){
//             sum = sum + i
//         }
//     }
//     return sum === number;
// }

// console.log(IsPerfectNumber(12));

//Task 6

// function FindPerfectNumber(min, max){
//     for (let i = min; i <= max; i++) {
//         if (IsPerfectNumber(i)) {
//             console.log(i);
//         }
//     }
// }

// FindPerfectNumber(1, 80)

//Task 7

// function formatTime(hours, minutes = 0, second = 0){
//     const h = String(hours).padStart(2, '0');
//     const m = String(minutes).padStart(2, '0');
//     const s = String(second).padStart(2, '0');
//     console.log(`${h}:${m}:${s}`);
// }

// formatTime(2,4,5)

//Task 8

function TimeToSecond(hour, minute = 0, second = 0){
    let total = (hour * 3600) + (minute * 60) + second;
    return total;
}

// console.log(TimeToSecond(1, 2, 3));

//Task 9

function SecondToTime(second = 0){
    let hours = Math.floor(second / 3600);

    second = second % 3600;
    let minutes = Math.floor(second / 60);

    second = second % 60;

    const h = String(hours).padStart(2, '0');
    const m = String(minutes).padStart(2, '0');
    const s = String(second).padStart(2, '0');

   return `${h}:${m}:${s}`;
}

// console.log(SecondToTime(123450))

//Task 10

function TimeDifference(h1, m1, s1, h2, m2, s2){
    let time1 = TimeToSecond(h1, m1, s1);
    let time2 = TimeToSecond(h2, m2, s2);

    let differ = time2 - time1;
    return SecondToTime(differ);
}

console.log(TimeDifference(1,1,1,4,3,3));