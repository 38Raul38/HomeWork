import React from "react";

const MyPet = (props) => {
    return (
        <div className="pet-card">
    <h1>Домашний любимец</h1>
    <img src="https://cdn.pixabay.com/photo/2016/02/10/16/37/cat-1192026_1280.jpg" alt="Фото питомца"/>
    <h2>Имя: Мурка</h2>
    <p><strong>Тип:</strong> Кошка</p>
    <p><strong>Порода:</strong> Шотландская вислоухая</p>
    <p><strong>Возраст:</strong> 3 года</p>
    <p><strong>Любимая еда:</strong> Тунец</p>
    <p><strong>Характер:</strong> Ласковая, игривая, обожает спать на окне</p>
  </div>
    );
}

export default MyPet;