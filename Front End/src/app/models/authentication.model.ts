export class Authentication {
username: string;
password: string;
grant_type: string;
client_id: string;
client_secret: string;

constructor() {
    this.grant_type = 'password';
    this.client_id = 'eb6dc5c9-9657-44a6-9415-c7f5758b7098';
    this.client_secret = '7qBOZNtpYS3Rho1RryMcskVzO0ql7P29wjGa2qct+7w=';
}
}