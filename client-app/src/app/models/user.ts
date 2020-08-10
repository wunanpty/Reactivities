export interface IUser {
    username: string;
    displayName: string;
    token: string;
    image?: string; // optional at this moment
}

// properties that we're going to send up to the server 
export interface IUserFormValues {
    email: string;
    password: string;
    displayName?: string;
    username?: string;
}