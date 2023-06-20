import React, {useContext, useState} from 'react';
import {observer} from "mobx-react-lite";
import {RootStateContext} from "../index"
import {Col, Row} from "react-bootstrap";
import UserItem from './UserItem';
import UserStore from '../store/UserStore';
import { UserAPI } from '../services/UserService';
import { IUser } from '../models/IUser';
import userEvent from '@testing-library/user-event';



const UserList = observer(() => {
    //const UserModel = new UserStore();

    const [limit, setLimit] = useState(10);
    const {data: users, error, isLoading, refetch} =  UserAPI.useFetchAllUsersQuery(limit)
    const [deleteUser, {}] = UserAPI.useDeleteUserMutation()

    //console.log(books)
    
   // useEffect(() => {
        // setTimeout(() => {
        // setLimit(3)
        // }, 2000)
    //}, [])

    const handleRemove = (user : IUser) => {
        deleteUser(user)
    }

    return (
        <Row style={{display: 'flex'}}>
            {users && users.map(user  =>
                <UserItem key={user.userId}  user={user} remove={handleRemove}/>
            )}
        </Row>
    );
});

export default UserList;