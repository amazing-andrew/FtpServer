using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FtpServer.Core
{
    /// <summary>Specifies the responce codes returned for a File Transfer Protocol (FTP) operation.</summary>
    public enum FtpResponceCode : int
    {
        /// <summary>Specifies that a user account on the server is required.</summary>
        AccountNeeded = 532,
        /// <summary>Specifies that an error occurred that prevented the request action from completing.</summary>
        ActionAbortedLocalProcessingError = 451,
        /// <summary>Specifies that the requested action cannot be taken because the specified page type is unknown. Page types are described in RFC 959 Section 3.1.2.3</summary>
        ActionAbortedUnknownPageType = 551,
        /// <summary>Specifies that the requested action cannot be performed on the specified file.</summary>
        ActionNotTakenFilenameNotAllowed = 553,
        /// <summary>Specifies that the requested action cannot be performed on the specified file because the file is not available.</summary>
        ActionNotTakenFileUnavailable = 550,
        /// <summary>Specifies that the requested action cannot be performed on the specified file because the file is not available or is being used.</summary>
        ActionNotTakenFileUnavailableOrBusy = 450,
        /// <summary>Specifies that the requested action cannot be performed because there is not enough space on the server.</summary>
        ActionNotTakenInsufficientSpace = 452,
        /// <summary>Specifies that one or more command arguments has a syntax error.</summary>
        ArgumentSyntaxError = 501,
        /// <summary>Specifies that the sequence of commands is not in the correct order.</summary>
        BadCommandSequence = 503,
        /// <summary>Specifies that the data connection cannot be opened.</summary>
        CantOpenData = 425,
        /// <summary>Specifies that the server is closing the control connection.</summary>
        ClosingControl = 221,
        /// <summary>Specifies that the server is closing the data connection and that the requested file action was successful.</summary>
        ClosingData = 226,
        /// <summary>Specifies that the command is not implemented by the server because it is not needed.</summary>
        CommandExtraneous = 202,
        /// <summary>Specifies that the command is not implemented by the FTP server.</summary>
        CommandNotImplemented = 502,
        /// <summary>Specifies that the command completed successfully.</summary>
        CommandOK = 200,
        /// <summary>Specifies that the command has a syntax error or is not a command recognized by the server.</summary>
        CommandSyntaxError = 500,
        /// <summary>Specifies that the connection has been closed.</summary>
        ConnectionClosed = 426,
        /// <summary>Specifies that the data connection is already open and the requested transfer is starting.</summary>
        DataAlreadyOpen = 125,
        /// <summary>Specifies the status of a directory.</summary>
        DirectoryStatus = 212,
        /// <summary>Specifies that the server is entering passive mode.</summary>
        EnteringPassive = 227,
        /// <summary>Specifies that the requested action cannot be performed.</summary>
        FileActionAborted = 552,
        /// <summary>Specifies that the requested file action completed successfully.</summary>
        FileActionOK = 250,
        /// <summary>Specifies that the requested file action requires additional information.</summary>
        FileCommandPending = 350,
        /// <summary>Specifies the status of a file.</summary>
        FileStatus = 213,
        /// <summary>Specifies that the user is logged in and can send commands.</summary>
        LoggedInProceed = 230,
        /// <summary>Specifies that the server requires a login account to be supplied.</summary>
        NeedLoginAccount = 332,
        /// <summary>Specifies that login information must be sent to the server.</summary>
        NotLoggedIn = 530,
        /// <summary>Specifies that the server is opening the data connection.</summary>
        OpeningData = 150,
        /// <summary>Specifies that the requested path name was created.</summary>
        PathnameCreated = 257,
        /// <summary>Specifies that the response contains a restart marker reply. The text of the description that accompanies this status contains the user data stream marker and the server marker.</summary>
        RestartMarker = 110,
        /// <summary>Specifies that the server expects a password to be supplied.</summary>
        SendPasswordCommand = 331,
        /// <summary>Specifies that the server is ready for a user login operation.</summary>
        SendUserCommand = 220,
        /// <summary>Specifies that the server accepts the authentication mechanism specified by the client, and the exchange of security data is complete.</summary>
        ServerWantsSecureSession = 234,
        /// <summary>Specifies that the service is not available.</summary>
        ServiceNotAvailable = 421,
        /// <summary>Specifies that the service is not available now; try your request later.</summary>
        ServiceTemporarilyNotAvailable = 120,
        /// <summary>Specifies the system type name using the system names published in the Assigned Numbers document published by the Internet Assigned Numbers Authority.</summary>
        SystemType = 215,
        /// <summary>Included for completeness, this value is never returned by servers.</summary>
        Undefined = 0
    }
}
