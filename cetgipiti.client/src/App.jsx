import { useState } from 'react';
import {
    Box,
    TextField,
    IconButton,
    List,
    ListItem,
    ListItemText,
    Paper,
    Typography,
} from '@mui/material';
import './App.css';
import SendIcon from '@mui/icons-material/Send';
function App() {
    const [messages, setMessages] = useState([]);
    const [input, setInput] = useState('');

    const handleSendMessage = () => {
        if (input.trim()) {
            setMessages([
                ...messages,
                { text: input, sender: 'You' },
                { text: 'This is a response from ChatGPT!', sender: 'ChatGPT' },
            ]);
            setInput('');
        }
    };

    return (
        <Paper
            elevation={3}
            sx={{
                width: 800,
                height: 900,
                display: 'flex',
                flexDirection: 'column',
                p: 2,
            }}
        >
            <Typography variant='h6' sx={{ textAlign: 'center', mb: 1 }}>
                CetGIPITI
            </Typography>
            <List sx={{ flexGrow: 1, overflowY: 'auto', maxHeight: 420 }}>
                {messages.map((msg, index) => (
                    <ListItem
                        key={index}
                        sx={{
                            justifyContent: msg.sender === 'You' ? 'flex-end' : 'flex-start',
                        }}
                    >
                        <ListItemText
                            primary={msg.text}
                            sx={{
                                backgroundColor: msg.sender === 'You' ? '#1976d2' : '#f5f5f5',
                                color: msg.sender === 'You' ? 'white' : 'black',
                                borderRadius: 2,
                                p: 1,
                                maxWidth: '75%',
                            }}
                        />
                    </ListItem>
                ))}
            </List>
            <Box
                sx={{
                    display: 'flex',
                    alignItems: 'center',
                    mt: 'auto',
                    pt: 1,
                    borderTop: '1px solid #ccc',
                }}
            >
                <TextField
                    fullWidth
                    variant='outlined'
                    size='small'
                    value={input}
                    onChange={e => setInput(e.target.value)}
                    onKeyPress={e => e.key === 'Enter' && handleSendMessage()}
                    placeholder='Yardýmcý olabileceðim bir konu varmýydý?'
                />
                <IconButton color='primary' onClick={handleSendMessage} sx={{ ml: 1 }}>
                    <SendIcon/>
                </IconButton>
            </Box>
        </Paper>
    );
    
}

export default App;