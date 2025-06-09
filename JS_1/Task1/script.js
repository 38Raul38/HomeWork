                                        // Task1
    let name = document.getElementById("name").addEventListener("beforeinput", function(e){
        const NextValue = e.target.value.substring(0, e.target.selectionStart) + (e.data ?? '') + e.target.value.substring(e.target.selectionEnd);
                            console.log(NextValue)                    
        if( /\d/g.test(NextValue)){
            e.preventDefault();
        }
    }); 

                   
                              
