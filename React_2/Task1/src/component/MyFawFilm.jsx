import React from "react";

const MyFilm = (props) => {
    return (
    <div className="container">
        <h1>Любимый кинофильм</h1>
        <h2>Название: Побег из Шоушенка</h2>
        <p><strong>Режиссер:</strong> Фрэнк Дарабонт</p>
        <p><strong>Год выпуска:</strong> 1994</p>
        <p><strong>Киностудия:</strong> Columbia Pictures / Castle Rock Entertainment</p>
        <img src="pobeg.jpg" alt="Постер фильма Побег из Шоушенка"/>
    </div>
    );
}

export default MyFilm;
