import React, { useEffect, useState } from "react";

const Mywatch = (props) => {
    let time = new Date().toLocaleTimeString();

    const [Ctime, setCtime] = useState(time);

    useEffect(() => {
        setInterval(() => {
                setCtime(new Date().toLocaleTimeString());
        }, 1000)
    }, []);

    
    return (
        <div className="content">
            <h1>{Ctime}</h1>
        </div>
    );
}

export default Mywatch;
