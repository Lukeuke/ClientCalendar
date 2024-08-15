import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";

const Authorized = ({ children }) => {
    const [isLogged, setLogged] = useState(-1);
    const navigate = useNavigate();

    useEffect(() => {
        let token = window.localStorage.getItem("jwt");
        
        fetch("/api/identity", {
            headers: {
                'Authorization': `Bearer ${token}`
            }
        })
            .then(res => {
                if (res.status === 200) {
                    setLogged(1);
                } else {
                    setLogged(0);
                }
            })
            .catch(err => {
                console.error(err);
                setLogged(0);
            });
    }, []);

    if (isLogged === -1) {
        return <>Loading...</>;
    }

    if (isLogged === 0) {
        navigate("/sign-in");
        return null;
    }

    return <>{children}</>;
};

export default Authorized;
