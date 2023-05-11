import { Navigate } from 'react-router-dom';
import Categories from './../components/pages/Categories/Categories';
import AddCategory from './../components/pages/AddCategory/AddCategory';
import UpdateCategory from './../components/pages/UpdateCategory/UpdateCategory';

export const routes = [
    { path: "/", element: <Categories />, exact: true },
    { path: "*", element: <Navigate to="/" />, exact: true },
    { path: "/категории", element: <Categories />, exact: true },
    { path: "/добавить_категорию", element: <AddCategory />, exact: true },
    { path: "/изменить_категорию/:name", element: <UpdateCategory />, exact: true },
];