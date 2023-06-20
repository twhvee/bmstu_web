import HomePage from "./HomePage"
import Auth from "./Auth"
import Register from "./Register"
import Books from './Books'
import Reviews from './Reviews'
import Users from './Users'
import ReviewPage from './ReviewPage'
import ProfilePage from './ProfilePage'

export const authRoutes = [
    
]

export const publicRoutes = [
    {
        path: '/home',
        Component: HomePage
    },
    {
        path: '/reviews' +'/:id',
        Component: ReviewPage
    },
    {
        path: '/books'+'/:id',
        Component: Books
    },
    {
        path: '/books',
        Component: Books
    },
    {
        path: '/users',
        Component: Users
    },
    {
        path: '/reviews',
        Component: Reviews
    },
    {
        path: '/auth',
        Component: Auth
    },
    {
        path: '/profile',
        Component: ProfilePage
    },
    {
        path: '/register',
        Component: Register
    },
]