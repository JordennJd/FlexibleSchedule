import {useEffect, useState} from "react";
import {Navigate} from 'react-router-dom';
import CodesComponent from "./CodesComponent.jsx";
import Header from "../Header/header__navigation";


const MyTimeTable = (props) => {
    const [redirect, setRedirect] = useState(false);
    const [Codes, setCodes] = useState([]);
    const [code,setCode] = useState()
    const GetCodes = () => {
        fetch("api/Group/GetAllGroupCodes")
            .then(response => {
                return response.json()
            })
            .then(responseJson => {
                setCodes(responseJson)
            })
    }
    
    useEffect(()=>{
        GetCodes()
    },[])
    
    const submit = async (e) => {
        e.preventDefault();
        await fetch('/api/Group/ConnectToGroup', {
            method: 'POST',
            credentials: "include",
            headers: {'Content-Type': 'application/json'},
            body: JSON.stringify({
                code,
            })
            
        });
        await GetCodes()
    }
    
    return (
        <>
            <Header user={props.user} setUser={props.setUser}/>

            <form onSubmit={submit}>
            <h1 className="h3 mb-3 fw-normal">Введите код группы для присоединения</h1>

            <input className="form-control" placeholder="Code" required
                   onChange={e => setCode(e.target.value)}
            />
            <button className="w-100 btn btn-lg btn-primary" type="submit">Submit</button>
        </form>
        <div>
            <CodesComponent GetCodes={GetCodes} Codes={Codes} setCodes={setCodes}></CodesComponent>
        </div>
        </>
    );
};

export default MyTimeTable;
